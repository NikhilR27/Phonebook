
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
insert into entry(name, number, phonebook_id) values('Nikhil', '0817071383', 1);