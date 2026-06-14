DROP DATABASE IF EXISTS HR_ApplicantSystem;
CREATE DATABASE HR_ApplicantSystem
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;
 
USE HR_ApplicantSystem;

CREATE TABLE Roles (
    RoleID      INT           NOT NULL AUTO_INCREMENT,
    RoleName    VARCHAR(50)   NOT NULL,
    Description VARCHAR(255)      NULL,
    CONSTRAINT pk_Roles        PRIMARY KEY (RoleID),
    CONSTRAINT uq_Roles_Name   UNIQUE      (RoleName)
);

CREATE TABLE Users (
    UserID       INT           NOT NULL AUTO_INCREMENT,
    RoleID       INT           NOT NULL,
    FirstName    VARCHAR(100)  NOT NULL,
    LastName     VARCHAR(100)  NOT NULL,
    Email        VARCHAR(150)  NOT NULL,
    PasswordHash VARCHAR(255)  NOT NULL,
    IsActive     TINYINT(1)    NOT NULL DEFAULT 1,
    CreatedAt    DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt    DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP
                                        ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT pk_Users        PRIMARY KEY (UserID),
    CONSTRAINT uq_Users_Email  UNIQUE      (Email),
    CONSTRAINT fk_Users_Role   FOREIGN KEY (RoleID)
                               REFERENCES  Roles(RoleID)
);

CREATE TABLE ApplicantAccounts (
    AccountID    INT           NOT NULL AUTO_INCREMENT,
    Email        VARCHAR(150)  NOT NULL,
    PasswordHash VARCHAR(255)  NOT NULL,
    IsActive     TINYINT(1)    NOT NULL DEFAULT 1,
    CreatedAt    DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt    DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP
                                        ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT pk_ApplicantAccounts       PRIMARY KEY (AccountID),
    CONSTRAINT uq_ApplicantAccounts_Email UNIQUE      (Email)
);

CREATE TABLE Applicants (
    ApplicantID    INT           NOT NULL AUTO_INCREMENT,
    AccountID      INT           NOT NULL,
    FirstName      VARCHAR(100)  NOT NULL,
    MiddleName     VARCHAR(100)      NULL,
    LastName       VARCHAR(100)  NOT NULL,
    DateOfBirth    DATE              NULL,
    Gender         VARCHAR(20)       NULL,
    -- Contact
    Phone          VARCHAR(30)       NULL,
    AltPhone       VARCHAR(30)       NULL,
    -- Address
    AddressLine1   VARCHAR(255)      NULL,
    AddressLine2   VARCHAR(255)      NULL,
    City           VARCHAR(100)      NULL,
    Province       VARCHAR(100)      NULL,
    ZipCode        VARCHAR(20)       NULL,
    Country        VARCHAR(100)      NULL DEFAULT 'Philippines',
    -- Education
    HighestDegree  VARCHAR(100)      NULL,
    SchoolName     VARCHAR(200)      NULL,
    FieldOfStudy   VARCHAR(150)      NULL,
    GradYear       YEAR              NULL,
    -- Skills & Experience
    Skills         TEXT              NULL,
    WorkExperience TEXT              NULL,
    CreatedAt      DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt      DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP
                                          ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT pk_Applicants         PRIMARY KEY (ApplicantID),
    CONSTRAINT uq_Applicants_Account UNIQUE      (AccountID),
    CONSTRAINT fk_Applicants_Account FOREIGN KEY (AccountID)
                                     REFERENCES  ApplicantAccounts(AccountID)
);
