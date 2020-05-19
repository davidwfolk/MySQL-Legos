-- CREATE TABLE legos (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(80) NOT NULL,
--   PRIMARY KEY (id)
-- )
-- ALTER TABLE legos DROP description;
-- ALTER TABLE legos ADD CreatorEmail varchar(255) NOT NULL;

-- CREATE TABLE sets(
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(20) NOT NULL,
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE setlegos(
--   id INT NOT NULL AUTO_INCREMENT,
--   legoId INT NOT NULL,
--   setId INT NOT NULL,
--   PRIMARY KEY (id),

--   INDEX (legoId),

--   FOREIGN KEY (legoId)
--     REFERENCES legos(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (setId)
--     REFERENCES sets(id)
--     ON DELETE CASCADE
-- )
-- SELECT * FROM legos WHERE Id = 7

-- NOTE Execute sql query command with ctrl + alt + e


-- DROP TABLE blocks