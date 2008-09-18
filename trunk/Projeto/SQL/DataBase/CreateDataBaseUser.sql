USE sgr;

GRANT USAGE ON *.* TO app@localhost IDENTIFIED BY 'pwd' REQUIRE NONE;
GRANT SELECT  ON SGR.* TO app@localhost;
GRANT INSERT  ON SGR.* TO app@localhost;
GRANT UPDATE  ON SGR.* TO app@localhost;
GRANT DELETE  ON SGR.* TO app@localhost;
GRANT CREATE  ON SGR.* TO app@localhost;
GRANT DROP  ON SGR.* TO app@localhost;
GRANT USAGE  ON SGR.* TO app@localhost WITH GRANT OPTION;
GRANT REFERENCES ON SGR.* TO app@localhost;
GRANT INDEX  ON SGR.* TO app@localhost;
GRANT ALTER  ON SGR.* TO app@localhost;
GRANT CREATE TEMPORARY TABLES ON SGR.* TO app@localhost;
GRANT LOCK TABLES  ON SGR.* TO app@localhost;
GRANT SHOW VIEW  ON SGR.* TO app@localhost;
GRANT EXECUTE  ON SGR.* TO app@localhost;
GRANT SELECT ON mysql.proc TO app@localhost;