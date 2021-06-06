CREATE DATABASE librarydb;

use librarydb;

CREATE SEQUENCE dbo.books_seq 
    START WITH 1  
    INCREMENT BY 1;  

CREATE TABLE dbo.books (
    ID INT PRIMARY KEY,
 BOOK_TITLE NVARCHAR(200) NOT NULL
);

CREATE SEQUENCE dbo.authors_seq 
    START WITH 1  
    INCREMENT BY 1;  

CREATE TABLE dbo.authors (
    ID INT PRIMARY KEY,
 SURNAME NVARCHAR(200) NOT NULL,
 FIRST_NAME NVARCHAR(200) NOT NULL,
 MIDDLE_NAME NVARCHAR(200)
);

CREATE TABLE dbo.authors_books (
 AUTHOR_ID INT,
 BOOK_ID INT,
 PRIMARY KEY(AUTHOR_ID, BOOK_ID),
    FOREIGN KEY(AUTHOR_ID) REFERENCES authors(ID),
    FOREIGN KEY(BOOK_ID) REFERENCES books(ID)
);

CREATE SEQUENCE dbo.storage_books_seq 
    START WITH 1  
    INCREMENT BY 1;  

CREATE TABLE dbo.storage_books (
    ID INT PRIMARY KEY,
 NUMBER_ROW INT NOT NULL,
 NUMBER_SHELF INT NOT NULL,
 NUMBER_SEAT INT NOT NULL,
 FILL_SLOT BIT
);

CREATE SEQUENCE dbo.exemplar_books_seq 
    START WITH 1  
    INCREMENT BY 1;  

CREATE TABLE dbo.exemplar_books (
    ID INT PRIMARY KEY,
 BOOK_ID INT,
 STORAGE_ID INT,
 PUBLISHER NVARCHAR(200),
 YEAR date,
 available bit,
 FOREIGN KEY(BOOK_ID) REFERENCES books(ID),
 FOREIGN KEY(STORAGE_ID) REFERENCES storage_books(ID)
);

CREATE SEQUENCE dbo.history_books_seq 
    START WITH 1  
    INCREMENT BY 1;  

CREATE TABLE dbo.history_books (
    ID INT PRIMARY KEY,
 EXEMPLAR_ID INT,
 ISSUE_DATE DATE NOT NULL,
 RETURN_DATE DATE,
 FOREIGN KEY(EXEMPLAR_ID) REFERENCES exemplar_books(ID)
);

alter table dbo.books add constraint AI_book_id default (next value for dbo.books_seq) for id;
alter table dbo.authors add constraint AI_author_id default (next value for dbo.authors_seq) for id;
alter table dbo.exemplar_books add constraint AI_exemplar_book_id default (next value for dbo.exemplar_books_seq) for id;
alter table dbo.storage_books add constraint AI_storage_book_id default (next value for dbo.storage_books_seq) for id;
alter table dbo.history_books add constraint AI_history_book_id default (next value for dbo.history_books_seq) for id;

CREATE PROC ADD_NEW_BOOK (
	@AUTHOR_SURNAME nvarchar(200),
	@AUTHOR_FIRST_NAME nvarchar(200),
	@BOOK_TITLE nvarchar(200),
	@PUBLISHER nvarchar(200),
	@YEAR varchar(4),
	@AUTHOR_MIDDLE_NAME nvarchar(200) = null,
	@COAUTHORS bit = 0)
AS
DECLARE 
	@ID_author INT,
	@ID_book INT,
	@ID_exemplar INT,
	@ID_storage INT,
	@CHECK_NEW_EXEMPLAR bit = 0
BEGIN
 /*Проверяем автора, если нет такого - добавляем*/
	SELECT @ID_author = COALESCE(max(a.ID), 0) from dbo.authors a
	 where a.SURNAME = @AUTHOR_SURNAME and a.FIRST_NAME = @AUTHOR_FIRST_NAME;

	IF @ID_author = 0
	BEGIN
		INSERT INTO dbo.authors (SURNAME, FIRST_NAME, MIDDLE_NAME)
		VALUES( @AUTHOR_SURNAME, @AUTHOR_FIRST_NAME, @AUTHOR_MIDDLE_NAME);

		SELECT @ID_author = max(a.ID) from dbo.authors a
		 where a.SURNAME = @AUTHOR_SURNAME and a.FIRST_NAME = @AUTHOR_FIRST_NAME;

		SET @CHECK_NEW_EXEMPLAR = 1; /*Если новый автор или новая книга, то нужно сделать связку*/
	END;

	IF @COAUTHORS = 0 /*Если не соавтор, то проверяем наличие книги в библиотеке*/
	BEGIN 
		/*Проверяем книгу в связке с автором*/
		SELECT @ID_book = COALESCE(max(b.ID), 0)
		  FROM dbo.authors a, dbo.books b, dbo.authors_books ab
		 WHERE a.ID = ab.AUTHOR_ID AND ab.BOOK_ID = b.ID
		   AND a.ID = @ID_author and b.BOOK_TITLE = @BOOK_TITLE;

		IF @ID_book = 0
		BEGIN
			INSERT INTO dbo.books (BOOK_TITLE)
			VALUES (@BOOK_TITLE);

			SELECT @ID_book = MAX(b.ID) 
			  FROM dbo.books b
			 WHERE b.BOOK_TITLE = @BOOK_TITLE;

			SET @CHECK_NEW_EXEMPLAR = 1; /*Если новый автор или новая книга, то нужно сделать связку*/
		END;
	END;
	ELSE
	BEGIN 
		/*Ищем книгу для соавтора*/
		SELECT @ID_book = MAX(b.ID) 
		  FROM dbo.books b
		 WHERE b.BOOK_TITLE = @BOOK_TITLE;

		SET @CHECK_NEW_EXEMPLAR = 1; /*Если соавтор, то нужно сделать связку*/
	END;

	/*Связываем книгу и автора*/
	IF @CHECK_NEW_EXEMPLAR = 1
	BEGIN
		INSERT into dbo.authors_books (AUTHOR_ID, BOOK_ID)
		VALUES (@ID_author, @ID_book);
	END;

	IF @COAUTHORS = 0 /*Если вносим соавтора, то создавать экземпляр не нужно*/
	BEGIN
		/*Ищем ближайщее не занятое место*/
		select @ID_storage = min(s.id)
		  FROM storage_books s
		 where s.FILL_SLOT = 0;
		/*Добавляем экземпляр*/
		INSERT into dbo.exemplar_books (BOOK_ID, STORAGE_ID, PUBLISHER, YEAR, available)
		VALUES (@ID_book, @ID_storage, @PUBLISHER, CONVERT(date, '01.01.' + @YEAR, 104), 1);

		/*Ставим отметку о занятом месте на полке*/
		UPDATE dbo.storage_books set fill_slot = 1 where ID = @ID_storage;
	END;
END;

CREATE VIEW dbo.REPORT_HISTORY_BOOKS
AS
select b.BOOK_TITLE
	 , (SELECT STRING_AGG (TRIM(a.SURNAME + N' ' + a.FIRST_NAME + N' ' + ISNULL(a.MIDDLE_NAME, N' ')), ', ') AS csv 
		  FROM dbo.authors a, dbo.authors_books ab
		 WHERE a.ID = ab.AUTHOR_ID AND ab.BOOK_ID = b.ID) AUTHOR
	 , (select count(*) from dbo.exemplar_books e where e.BOOK_ID = b.ID) EXEMPLAR_COUNT
	 , h.ISSUE_DATE
	 , h.RETURN_DATE
	 , e.available
  from dbo.books b, dbo.exemplar_books e
  left join dbo.history_books h on e.ID = h.EXEMPLAR_ID
 where b.ID = e.BOOK_ID;

 CREATE PROC Report_history_book (@START_DATE date, @END_DATE date)
AS
	select rhb.book_title, rhb.author, rhb.exemplar_count, count(*) issue_in_period
		 , sum(cast(rhb.available as INT)) available_count
	  from dbo.report_history_books rhb
	 where rhb.issue_date between @START_DATE and @END_DATE
	 group by rhb.book_title, rhb.author, rhb.exemplar_count
	union
	select rhb.book_title, rhb.author, rhb.exemplar_count, 0 issue_in_period
		 , sum(cast(rhb.available as INT)) available_count
	  from dbo.report_history_books rhb
	 where (rhb.issue_date not between @START_DATE and @END_DATE) or rhb.issue_date is null
	 group by rhb.book_title, rhb.author, rhb.exemplar_count
	 order by issue_in_period DESC, book_title
 ;