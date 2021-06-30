
CREATE TABLE phonebook
(
    id serial PRIMARY KEY,
    name  VARCHAR (50)  NOT NULL
);

CREATE TABLE entry
(
    id serial PRIMARY KEY,
    name  VARCHAR (50)  NOT NULL,
    number  VARCHAR (20)  NOT NULL,
    phonebook_id int NOT NULL,
CONSTRAINT fk_entry_phonebook
    FOREIGN KEY (phonebook_id)
    REFERENCES phonebook(id) 
);

ALTER TABLE "entry" OWNER TO dbuser;
ALTER TABLE "phonebook" OWNER TO dbuser;

insert into phonebook(name) values('CIB Digital Phonebook');
insert into entry(name, number, phonebook_id) values('Nikhil Ramdass', '0817071383', 1);
insert into entry(name, number, phonebook_id) values('Jon Snow', '071334873', 1);
insert into entry(name, number, phonebook_id) values('Bruce Wayne', '1234567890', 1);
insert into entry(name, number, phonebook_id) values('Frodo Baggins', '0987654321', 1);
insert into entry(name, number, phonebook_id) values('Peter Crouch', '0819080883', 1);
insert into entry(name, number, phonebook_id) values('Hashim Amla', '7777888812', 1);