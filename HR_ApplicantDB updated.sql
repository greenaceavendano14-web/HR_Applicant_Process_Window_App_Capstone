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

CREATE TABLE Departments (
    DepartmentID   INT          NOT NULL AUTO_INCREMENT,
    DepartmentName VARCHAR(100) NOT NULL,
    Description    VARCHAR(255)     NULL,
    IsActive       TINYINT(1)   NOT NULL DEFAULT 1,
    CONSTRAINT pk_Departments      PRIMARY KEY (DepartmentID),
    CONSTRAINT uq_Departments_Name UNIQUE      (DepartmentName)
);

CREATE TABLE EmploymentTypes (
    EmploymentTypeID INT         NOT NULL AUTO_INCREMENT,
    TypeName         VARCHAR(100) NOT NULL,
    IsActive         TINYINT(1)  NOT NULL DEFAULT 1,
    CONSTRAINT pk_EmploymentTypes      PRIMARY KEY (EmploymentTypeID),
    CONSTRAINT uq_EmploymentTypes_Name UNIQUE      (TypeName)
);

CREATE TABLE InterviewTypes (
    InterviewTypeID INT         NOT NULL AUTO_INCREMENT,
    TypeName        VARCHAR(100) NOT NULL,
    IsActive        TINYINT(1)  NOT NULL DEFAULT 1,
    CONSTRAINT pk_InterviewTypes      PRIMARY KEY (InterviewTypeID),
    CONSTRAINT uq_InterviewTypes_Name UNIQUE      (TypeName)
);

CREATE TABLE AssessmentTypes (
    AssessmentTypeID INT         NOT NULL AUTO_INCREMENT,
    TypeName         VARCHAR(100) NOT NULL,
    IsActive         TINYINT(1)  NOT NULL DEFAULT 1,
    CONSTRAINT pk_AssessmentTypes      PRIMARY KEY (AssessmentTypeID),
    CONSTRAINT uq_AssessmentTypes_Name UNIQUE      (TypeName)
);

CREATE TABLE RequirementTypes (
    RequirementTypeID INT         NOT NULL AUTO_INCREMENT,
    TypeName          VARCHAR(100) NOT NULL,
    Description       VARCHAR(255)     NULL,
    IsMandatory       TINYINT(1)  NOT NULL DEFAULT 1,
    IsActive          TINYINT(1)  NOT NULL DEFAULT 1,
    CONSTRAINT pk_RequirementTypes      PRIMARY KEY (RequirementTypeID),
    CONSTRAINT uq_RequirementTypes_Name UNIQUE      (TypeName)
);
 
 CREATE TABLE JobVacancies (
    VacancyID        INT          NOT NULL AUTO_INCREMENT,
    DepartmentID     INT          NOT NULL,
    EmploymentTypeID INT          NOT NULL,
    JobTitle         VARCHAR(150) NOT NULL,
    JobDescription   TEXT             NULL,
    Qualifications   TEXT             NULL,
    SlotsAvailable   INT          NOT NULL DEFAULT 1,
    PostedDate       DATE         NOT NULL,
    ClosingDate      DATE             NULL,
    Status           ENUM('Open','Closed','On Hold') NOT NULL DEFAULT 'Open',
    CreatedByUserID  INT          NOT NULL,
    CreatedAt        DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt        DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP
                                           ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT pk_JobVacancies          PRIMARY KEY (VacancyID),
    CONSTRAINT fk_JobVacancies_Dept     FOREIGN KEY (DepartmentID)
                                        REFERENCES  Departments(DepartmentID),
    CONSTRAINT fk_JobVacancies_EmpType  FOREIGN KEY (EmploymentTypeID)
                                        REFERENCES  EmploymentTypes(EmploymentTypeID),
    CONSTRAINT fk_JobVacancies_Creator  FOREIGN KEY (CreatedByUserID)
                                        REFERENCES  Users(UserID)
);

CREATE TABLE VacancyRequirements (
    VacancyReqID      INT NOT NULL AUTO_INCREMENT,
    VacancyID         INT NOT NULL,
    RequirementTypeID INT NOT NULL,
    CONSTRAINT pk_VacancyRequirements    PRIMARY KEY (VacancyReqID),
    CONSTRAINT uq_VacancyRequirements    UNIQUE      (VacancyID, RequirementTypeID),
    CONSTRAINT fk_VacReq_Vacancy         FOREIGN KEY (VacancyID)
                                         REFERENCES  JobVacancies(VacancyID),
    CONSTRAINT fk_VacReq_ReqType         FOREIGN KEY (RequirementTypeID)
                                         REFERENCES  RequirementTypes(RequirementTypeID)
);

CREATE TABLE Applications (
    ApplicationID INT      NOT NULL AUTO_INCREMENT,
    ApplicantID   INT      NOT NULL,
    VacancyID     INT      NOT NULL,
    CurrentStatus ENUM(
                      'Draft',
                      'Submitted',
                      'Under Review',
                      'Shortlisted',
                      'For Interview',
                      'For Assessment',
                      'For Final Review',
                      'Accepted',
                      'Rejected',
                      'Withdrawn'
                  )        NOT NULL DEFAULT 'Draft',
    SubmittedAt   DATETIME     NULL,
    CreatedAt     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                                    ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT pk_Applications       PRIMARY KEY (ApplicationID),
    CONSTRAINT uq_Applications       UNIQUE      (ApplicantID, VacancyID),
    CONSTRAINT fk_Applications_Appl  FOREIGN KEY (ApplicantID)
                                     REFERENCES  Applicants(ApplicantID),
    CONSTRAINT fk_Applications_Vac   FOREIGN KEY (VacancyID)
                                     REFERENCES  JobVacancies(VacancyID)
);
 
-- ----------------------------------------------------------------
-- 13. ApplicationStatusHistory
-- ----------------------------------------------------------------
CREATE TABLE ApplicationStatusHistory (
    HistoryID     INT         NOT NULL AUTO_INCREMENT,
    ApplicationID INT         NOT NULL,
    OldStatus     VARCHAR(50)     NULL,
    NewStatus     VARCHAR(50) NOT NULL,
    ChangedByType ENUM('Applicant','HR Staff','HR Manager','Admin','System') NOT NULL,
    ChangedByID   INT             NULL,
    Remarks       TEXT            NULL,
    ChangedAt     DATETIME    NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_AppStatusHistory      PRIMARY KEY (HistoryID),
    CONSTRAINT fk_AppStatusHistory_App  FOREIGN KEY (ApplicationID)
                                        REFERENCES  Applications(ApplicationID)
);
 
 CREATE TABLE ApplicantDocuments (
    DocumentID        INT          NOT NULL AUTO_INCREMENT,
    ApplicationID     INT          NOT NULL,
    RequirementTypeID INT          NOT NULL,
    FilePath          VARCHAR(500)     NULL,
    FileName          VARCHAR(255)     NULL,
    SubmissionStatus  ENUM('Submitted','Missing','Rejected') NOT NULL DEFAULT 'Missing',
    HRRemarks         TEXT             NULL,
    UploadedAt        DATETIME         NULL,
    UpdatedAt         DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP
                                            ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT pk_ApplicantDocuments      PRIMARY KEY (DocumentID),
    CONSTRAINT uq_ApplicantDocuments      UNIQUE      (ApplicationID, RequirementTypeID),
    CONSTRAINT fk_ApplDocs_App            FOREIGN KEY (ApplicationID)
                                          REFERENCES  Applications(ApplicationID),
    CONSTRAINT fk_ApplDocs_ReqType        FOREIGN KEY (RequirementTypeID)
                                          REFERENCES  RequirementTypes(RequirementTypeID)
);

CREATE TABLE ScreeningResults (
    ScreeningID      INT      NOT NULL AUTO_INCREMENT,
    ApplicationID    INT      NOT NULL,
    ScreenedByUserID INT      NOT NULL,
    Result           ENUM('Qualified','Not Qualified') NOT NULL,
    Remarks          TEXT         NULL,
    ScreenedAt       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_ScreeningResults      PRIMARY KEY (ScreeningID),
    CONSTRAINT uq_ScreeningResults      UNIQUE      (ApplicationID),
    CONSTRAINT fk_Screening_App         FOREIGN KEY (ApplicationID)
                                        REFERENCES  Applications(ApplicationID),
    CONSTRAINT fk_Screening_User        FOREIGN KEY (ScreenedByUserID)
                                        REFERENCES  Users(UserID)
);

CREATE TABLE InterviewSchedules (
    ScheduleID        INT          NOT NULL AUTO_INCREMENT,
    ApplicationID     INT          NOT NULL,
    InterviewTypeID   INT          NOT NULL,
    InterviewerUserID INT          NOT NULL,
    ScheduledDate     DATE         NOT NULL,
    ScheduledTime     TIME         NOT NULL,
    Mode              ENUM('Face-to-Face','Online','Phone') NOT NULL DEFAULT 'Face-to-Face',
    Location          VARCHAR(255)     NULL,
    MeetingLink       VARCHAR(500)     NULL,
    Status            ENUM('Scheduled','Completed','Cancelled','Rescheduled') NOT NULL DEFAULT 'Scheduled',
    CreatedByUserID   INT          NOT NULL,
    CreatedAt         DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt         DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP
                                            ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT pk_InterviewSchedules        PRIMARY KEY (ScheduleID),
    CONSTRAINT fk_IntSched_App              FOREIGN KEY (ApplicationID)
                                            REFERENCES  Applications(ApplicationID),
    CONSTRAINT fk_IntSched_IntType          FOREIGN KEY (InterviewTypeID)
                                            REFERENCES  InterviewTypes(InterviewTypeID),
    CONSTRAINT fk_IntSched_Interviewer      FOREIGN KEY (InterviewerUserID)
                                            REFERENCES  Users(UserID),
    CONSTRAINT fk_IntSched_CreatedBy        FOREIGN KEY (CreatedByUserID)
                                            REFERENCES  Users(UserID)
);

CREATE TABLE InterviewEvaluations (
    EvaluationID      INT           NOT NULL AUTO_INCREMENT,
    ScheduleID        INT           NOT NULL,
    EvaluatedByUserID INT           NOT NULL,
    Score             DECIMAL(5,2)      NULL,
    Result            ENUM('Pass','Fail','Pending') NOT NULL DEFAULT 'Pending',
    Remarks           TEXT              NULL,
    Recommendation    TEXT              NULL,
    EvaluatedAt       DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_InterviewEvaluations    PRIMARY KEY (EvaluationID),
    CONSTRAINT uq_InterviewEvaluations    UNIQUE      (ScheduleID),
    CONSTRAINT fk_IntEval_Schedule        FOREIGN KEY (ScheduleID)
                                          REFERENCES  InterviewSchedules(ScheduleID),
    CONSTRAINT fk_IntEval_User            FOREIGN KEY (EvaluatedByUserID)
                                          REFERENCES  Users(UserID)
);

CREATE TABLE HiringDecisions (
    DecisionID      INT      NOT NULL AUTO_INCREMENT,
    ApplicationID   INT      NOT NULL,
    DecidedByUserID INT      NOT NULL,
    Decision        ENUM('Accepted','Rejected','On Hold') NOT NULL,
    Remarks         TEXT         NULL,
    DecidedAt       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_HiringDecisions       PRIMARY KEY (DecisionID),
    CONSTRAINT uq_HiringDecisions       UNIQUE      (ApplicationID),
    CONSTRAINT fk_HiringDec_App         FOREIGN KEY (ApplicationID)
                                        REFERENCES  Applications(ApplicationID),
    CONSTRAINT fk_HiringDec_User        FOREIGN KEY (DecidedByUserID)
                                        REFERENCES  Users(UserID)
);

CREATE TABLE AuditTrail (
    AuditID     INT          NOT NULL AUTO_INCREMENT,
    ActorType   ENUM('Applicant','HR Staff','HR Manager','Admin','System') NOT NULL,
    ActorID     INT          NOT NULL,
    Action      VARCHAR(100) NOT NULL,
    TargetTable VARCHAR(100)     NULL,
    TargetID    INT              NULL,
    Details     TEXT             NULL,
    IPAddress   VARCHAR(45)      NULL,
    CreatedAt   DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_AuditTrail PRIMARY KEY (AuditID)
);

CREATE INDEX idx_Applications_Status      ON Applications(CurrentStatus);
CREATE INDEX idx_Applications_Applicant   ON Applications(ApplicantID);
CREATE INDEX idx_Applications_Vacancy     ON Applications(VacancyID);
CREATE INDEX idx_StatusHistory_AppID      ON ApplicationStatusHistory(ApplicationID);
CREATE INDEX idx_ApplDocs_AppID           ON ApplicantDocuments(ApplicationID);
CREATE INDEX idx_IntSched_AppID           ON InterviewSchedules(ApplicationID);
CREATE INDEX idx_JobVacancies_Status      ON JobVacancies(Status);
CREATE INDEX idx_AuditTrail_Actor         ON AuditTrail(ActorType, ActorID);

-- Roles
INSERT INTO Roles (RoleName, Description) VALUES
('Admin',      'Full system access'),
('HR Manager', 'Final hiring decisions and vacancy management'),
('HR Staff',   'Review, screen, and schedule interviews');
 
-- Users (passwords are SHA2-256 hashed)
INSERT INTO Users (RoleID, FirstName, LastName, Email, PasswordHash) VALUES
(1, 'System',  'Admin',   'admin@company.com',    SHA2('Admin@1234',   256)),
(2, 'Maria',   'Santos',  'm.santos@company.com', SHA2('Manager@1234', 256)),
(3, 'Jose',    'Reyes',   'j.reyes@company.com',  SHA2('Staff@1234',   256)),
(3, 'Ana',     'Cruz',    'a.cruz@company.com',   SHA2('Staff@1234',   256));
 
-- Departments
INSERT INTO Departments (DepartmentName, Description) VALUES
('Human Resources',        'HR and recruitment operations'),
('Information Technology', 'Software and systems development'),
('Finance',                'Accounting and financial management'),
('Operations',             'Business operations and logistics');
 
-- Employment Types
INSERT INTO EmploymentTypes (TypeName) VALUES
('Full-time'),
('Part-time'),
('Contractual'),
('Project-based'),
('Internship');
 
-- Interview Types
INSERT INTO InterviewTypes (TypeName) VALUES
('Initial HR Interview'),
('Technical Interview'),
('Panel Interview'),
('Final Interview');
 
-- Assessment Types
INSERT INTO AssessmentTypes (TypeName) VALUES
('Written Exam'),
('Technical Skills Test'),
('Psychological Exam'),
('Background Check');
 
-- Requirement Types
INSERT INTO RequirementTypes (TypeName, IsMandatory) VALUES
('Resume / CV',               1),
('Transcript of Records',     1),
('Valid Government ID',       1),
('Birth Certificate',         0),
('NBI Clearance',             1),
('Medical Certificate',       0),
('Certificate of Employment', 0),
('Diploma / Degree',          1);
 
-- Job Vacancies
INSERT INTO JobVacancies
    (DepartmentID, EmploymentTypeID, JobTitle, JobDescription,
     Qualifications, SlotsAvailable, PostedDate, ClosingDate, Status, CreatedByUserID)
VALUES
(2, 1, 'Junior Software Developer',
 'Develop and maintain internal applications using C# and .NET.',
 'Graduate of BSCS, BSIT or related field. Fresh graduates welcome.',
 3, '2025-05-01', '2025-07-01', 'Open', 2),
 
(2, 1, 'IT Support Specialist',
 'Provide technical support to all departments.',
 'At least 1 year experience in IT support. CCNA is an advantage.',
 2, '2025-05-10', '2025-06-30', 'Open', 2),
 
(3, 1, 'Accounting Staff',
 'Handle accounts payable, receivable, and general ledger.',
 'Graduate of BS Accountancy or BS Accounting Technology. CPA is an advantage.',
 1, '2025-04-15', '2025-06-15', 'Open', 3),
 
(1, 3, 'HR Recruitment Assistant',
 'Assist in end-to-end recruitment activities.',
 'Graduate of BSHRM, Psychology, or related field.',
 1, '2025-05-20', '2025-07-20', 'Open', 3);
 
-- Vacancy Requirements
-- Junior Software Developer  → Resume, TOR, Gov ID, NBI, Diploma
INSERT INTO VacancyRequirements (VacancyID, RequirementTypeID) VALUES
(1,1),(1,2),(1,3),(1,5),(1,8),
-- IT Support Specialist      → Resume, Gov ID, NBI
(2,1),(2,3),(2,5),
-- Accounting Staff           → Resume, TOR, Gov ID, NBI, Cert of Employment, Diploma
(3,1),(3,2),(3,3),(3,5),(3,7),(3,8),
-- HR Recruitment Assistant   → Resume, TOR, Gov ID, NBI
(4,1),(4,2),(4,3),(4,5);
 
-- Applicant Accounts
INSERT INTO ApplicantAccounts (Email, PasswordHash) VALUES
('juan.delacruz@email.com',  SHA2('Applicant@1234', 256)),
('maria.garcia@email.com',   SHA2('Applicant@1234', 256)),
('pedro.mendoza@email.com',  SHA2('Applicant@1234', 256));
 
-- Applicant Profiles
INSERT INTO Applicants
    (AccountID, FirstName, LastName, DateOfBirth, Gender,
     Phone, City, Province,
     HighestDegree, SchoolName, FieldOfStudy, GradYear, Skills)
VALUES
(1, 'Juan',  'Dela Cruz', '2000-03-15', 'Male',
 '09171234567', 'Las Piñas',  'Metro Manila',
 'Bachelor''s Degree', 'PLM',  'BS Computer Science',       2023, 'C#, SQL, HTML, CSS'),
 
(2, 'Maria', 'Garcia',    '1999-07-22', 'Female',
 '09281234567', 'Muntinlupa', 'Metro Manila',
 'Bachelor''s Degree', 'UPM',  'BS Accountancy',            2022, 'Accounting, MS Excel, QuickBooks'),
 
(3, 'Pedro', 'Mendoza',   '2001-01-10', 'Male',
 '09391234567', 'Parañaque',  'Metro Manila',
 'Bachelor''s Degree', 'DLSU', 'BS Information Technology', 2024, 'Networking, Windows Server, CCNA');
 
-- Applications
INSERT INTO Applications (ApplicantID, VacancyID, CurrentStatus, SubmittedAt) VALUES
(1, 1, 'Under Review',  '2025-05-25 09:00:00'),   -- App 1: Juan  → Jr. Software Dev
(2, 3, 'Shortlisted',   '2025-05-26 10:30:00'),   -- App 2: Maria → Accounting Staff
(3, 2, 'For Interview', '2025-05-27 08:45:00'),   -- App 3: Pedro → IT Support
(1, 4, 'Draft',          NULL);                    -- App 4: Juan  → HR Assistant (draft)
 
-- Application Status History
INSERT INTO ApplicationStatusHistory
    (ApplicationID, OldStatus, NewStatus, ChangedByType, ChangedByID, Remarks)
VALUES
-- App 1 (Juan)
(1, NULL,           'Draft',          'Applicant', 1, 'Application created.'),
(1, 'Draft',        'Submitted',      'Applicant', 1, 'Applicant submitted the application.'),
(1, 'Submitted',    'Under Review',   'HR Staff',  3, 'HR started reviewing documents.'),
-- App 2 (Maria)
(2, NULL,           'Draft',          'Applicant', 2, 'Application created.'),
(2, 'Draft',        'Submitted',      'Applicant', 2, 'Applicant submitted the application.'),
(2, 'Submitted',    'Under Review',   'HR Staff',  4, 'Documents validated.'),
(2, 'Under Review', 'Shortlisted',    'HR Staff',  4, 'Applicant meets all qualifications.'),
-- App 3 (Pedro)
(3, NULL,           'Draft',          'Applicant', 3, 'Application created.'),
(3, 'Draft',        'Submitted',      'Applicant', 3, 'Applicant submitted the application.'),
(3, 'Submitted',    'Under Review',   'HR Staff',  3, 'Documents under review.'),
(3, 'Under Review', 'Shortlisted',    'HR Staff',  3, 'Passed initial screening.'),
(3, 'Shortlisted',  'For Interview',  'HR Staff',  3, 'Interview has been scheduled.');
 
-- Applicant Documents
INSERT INTO ApplicantDocuments
    (ApplicationID, RequirementTypeID, FilePath, FileName, SubmissionStatus, UploadedAt)
VALUES
-- App 1: Juan (Junior Software Developer) — NBI missing
(1, 1, '/uploads/app1/resume.pdf',   'resume.pdf',   'Submitted', '2025-05-25 09:05:00'),
(1, 2, '/uploads/app1/tor.pdf',      'tor.pdf',       'Submitted', '2025-05-25 09:07:00'),
(1, 3, '/uploads/app1/gov_id.jpg',   'gov_id.jpg',    'Submitted', '2025-05-25 09:08:00'),
(1, 5,  NULL,                         NULL,            'Missing',   NULL),
(1, 8, '/uploads/app1/diploma.pdf',  'diploma.pdf',   'Submitted', '2025-05-25 09:10:00'),
-- App 2: Maria (Accounting Staff) — Cert of Employment missing
(2, 1, '/uploads/app2/resume.pdf',   'resume.pdf',   'Submitted', '2025-05-26 10:35:00'),
(2, 2, '/uploads/app2/tor.pdf',      'tor.pdf',       'Submitted', '2025-05-26 10:36:00'),
(2, 3, '/uploads/app2/gov_id.jpg',   'gov_id.jpg',    'Submitted', '2025-05-26 10:37:00'),
(2, 5, '/uploads/app2/nbi.pdf',      'nbi.pdf',       'Submitted', '2025-05-26 10:38:00'),
(2, 7,  NULL,                         NULL,            'Missing',   NULL),
(2, 8, '/uploads/app2/diploma.pdf',  'diploma.pdf',   'Submitted', '2025-05-26 10:39:00'),
-- App 3: Pedro (IT Support Specialist) — all submitted
(3, 1, '/uploads/app3/resume.pdf',   'resume.pdf',   'Submitted', '2025-05-27 08:50:00'),
(3, 3, '/uploads/app3/gov_id.jpg',   'gov_id.jpg',    'Submitted', '2025-05-27 08:52:00'),
(3, 5, '/uploads/app3/nbi.pdf',      'nbi.pdf',       'Submitted', '2025-05-27 08:53:00');
 
-- Screening Results
INSERT INTO ScreeningResults (ApplicationID, ScreenedByUserID, Result, Remarks) VALUES
(1, 3, 'Qualified',  'Meets educational and skill requirements.'),
(2, 4, 'Qualified',  'BS Accountancy graduate; good academic standing.'),
(3, 3, 'Qualified',  'IT-related course; has networking background.');
 
-- Interview Schedule
INSERT INTO InterviewSchedules
    (ApplicationID, InterviewTypeID, InterviewerUserID,
     ScheduledDate, ScheduledTime, Mode, Location, Status, CreatedByUserID)
VALUES
(3, 1, 3, '2025-06-10', '10:00:00', 'Face-to-Face', 'HR Office Room 2', 'Scheduled', 3);
 
-- Audit Trail
INSERT INTO AuditTrail (ActorType, ActorID, Action, TargetTable, TargetID, Details) VALUES
('Applicant', 1, 'LOGIN',             NULL,                  NULL, 'Applicant logged in.'),
('Applicant', 1, 'APPLICATION_SUBMIT','Applications',           1, 'Submitted application for Junior Software Developer.'),
('HR Staff',  3, 'STATUS_CHANGE',     'Applications',           1, 'Status: Submitted → Under Review.'),
('HR Staff',  4, 'STATUS_CHANGE',     'Applications',           2, 'Status: Under Review → Shortlisted.'),
('HR Staff',  3, 'INTERVIEW_SCHEDULE','InterviewSchedules',      1, 'Interview scheduled for ApplicationID 3.');
 
-- View 1: Missing documents per application
CREATE OR REPLACE VIEW vw_MissingDocuments AS
SELECT
    a.ApplicationID,
    CONCAT(ap.FirstName, ' ', ap.LastName)        AS ApplicantName,
    jv.JobTitle,
    rt.TypeName                                   AS RequirementType,
    COALESCE(ad.SubmissionStatus, 'Missing')      AS DocStatus
FROM Applications a
JOIN Applicants        ap ON a.ApplicantID          = ap.ApplicantID
JOIN JobVacancies      jv ON a.VacancyID             = jv.VacancyID
JOIN VacancyRequirements vr ON jv.VacancyID          = vr.VacancyID
JOIN RequirementTypes  rt ON vr.RequirementTypeID    = rt.RequirementTypeID
LEFT JOIN ApplicantDocuments ad
       ON a.ApplicationID        = ad.ApplicationID
      AND vr.RequirementTypeID   = ad.RequirementTypeID
WHERE COALESCE(ad.SubmissionStatus, 'Missing') = 'Missing';
 
-- View 2: Application summary for HR dashboard
CREATE OR REPLACE VIEW vw_ApplicationSummary AS
SELECT
    a.ApplicationID,
    CONCAT(ap.FirstName, ' ', ap.LastName)        AS ApplicantName,
    jv.JobTitle,
    d.DepartmentName,
    a.CurrentStatus,
    a.SubmittedAt,
    (SELECT COUNT(*)
     FROM   ApplicantDocuments ad2
     WHERE  ad2.ApplicationID    = a.ApplicationID
       AND  ad2.SubmissionStatus = 'Missing')     AS MissingDocCount
FROM Applications  a
JOIN Applicants    ap ON a.ApplicantID   = ap.ApplicantID
JOIN JobVacancies  jv ON a.VacancyID     = jv.VacancyID
JOIN Departments    d ON jv.DepartmentID = d.DepartmentID;
 
-- View 3: Status timeline per application
CREATE OR REPLACE VIEW vw_StatusTimeline AS
SELECT
    ash.ApplicationID,
    CONCAT(ap.FirstName, ' ', ap.LastName)        AS ApplicantName,
    ash.OldStatus,
    ash.NewStatus,
    ash.ChangedByType,
    ash.Remarks,
    ash.ChangedAt
FROM ApplicationStatusHistory ash
JOIN Applications a ON ash.ApplicationID = a.ApplicationID
JOIN Applicants  ap ON a.ApplicantID     = ap.ApplicantID
ORDER BY ash.ApplicationID, ash.ChangedAt;
 
-- View 4: Pending applications (HR report)
CREATE OR REPLACE VIEW vw_PendingApplications AS
SELECT
    a.ApplicationID,
    CONCAT(ap.FirstName, ' ', ap.LastName)        AS ApplicantName,
    ap.Phone,
    jv.JobTitle,
    d.DepartmentName,
    a.CurrentStatus,
    a.SubmittedAt
FROM Applications  a
JOIN Applicants    ap ON a.ApplicantID   = ap.ApplicantID
JOIN JobVacancies  jv ON a.VacancyID     = jv.VacancyID
JOIN Departments    d ON jv.DepartmentID = d.DepartmentID
WHERE a.CurrentStatus NOT IN ('Accepted','Rejected','Withdrawn','Draft');
 
-- View 5: Final hiring results (HR report)
CREATE OR REPLACE VIEW vw_HiringResults AS
SELECT
    hd.DecisionID,
    CONCAT(ap.FirstName, ' ', ap.LastName)        AS ApplicantName,
    jv.JobTitle,
    d.DepartmentName,
    hd.Decision,
    hd.Remarks                                    AS DecisionRemarks,
    CONCAT(u.FirstName,  ' ', u.LastName)         AS DecidedBy,
    hd.DecidedAt
FROM HiringDecisions hd
JOIN Applications  a  ON hd.ApplicationID   = a.ApplicationID
JOIN Applicants    ap ON a.ApplicantID       = ap.ApplicantID
JOIN JobVacancies  jv ON a.VacancyID         = jv.VacancyID
JOIN Departments    d ON jv.DepartmentID     = d.DepartmentID
JOIN Users          u ON hd.DecidedByUserID  = u.UserID;

DELIMITER $$
 
-- SP 1: Submit an Application (Draft → Submitted)
CREATE PROCEDURE sp_SubmitApplication (
    IN p_ApplicationID INT,
    IN p_ApplicantID   INT
)
BEGIN
    DECLARE v_Status VARCHAR(50);
 
    SELECT CurrentStatus INTO v_Status
    FROM   Applications
    WHERE  ApplicationID = p_ApplicationID
      AND  ApplicantID   = p_ApplicantID;
 
    IF v_Status IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Application not found.';
    ELSEIF v_Status <> 'Draft' THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Only Draft applications can be submitted.';
    ELSE
        UPDATE Applications
        SET    CurrentStatus = 'Submitted', SubmittedAt = NOW()
        WHERE  ApplicationID = p_ApplicationID;
 
        INSERT INTO ApplicationStatusHistory
            (ApplicationID, OldStatus, NewStatus, ChangedByType, ChangedByID, Remarks)
        VALUES
            (p_ApplicationID, 'Draft', 'Submitted', 'Applicant', p_ApplicantID,
             'Application submitted by applicant.');
 
        INSERT INTO AuditTrail (ActorType, ActorID, Action, TargetTable, TargetID, Details)
        VALUES ('Applicant', p_ApplicantID, 'APPLICATION_SUBMIT', 'Applications',
                p_ApplicationID, CONCAT('ApplicationID ', p_ApplicationID, ' submitted.'));
    END IF;
END$$
 
-- SP 2: Change Application Status (HR use)
CREATE PROCEDURE sp_ChangeApplicationStatus (
    IN p_ApplicationID INT,
    IN p_NewStatus     VARCHAR(50),
    IN p_ChangedByType VARCHAR(20),
    IN p_ChangedByID   INT,
    IN p_Remarks       TEXT
)
BEGIN
    DECLARE v_OldStatus VARCHAR(50);
 
    SELECT CurrentStatus INTO v_OldStatus
    FROM   Applications
    WHERE  ApplicationID = p_ApplicationID;
 
    IF v_OldStatus IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Application not found.';
    ELSE
        UPDATE Applications
        SET    CurrentStatus = p_NewStatus
        WHERE  ApplicationID = p_ApplicationID;
 
        INSERT INTO ApplicationStatusHistory
            (ApplicationID, OldStatus, NewStatus, ChangedByType, ChangedByID, Remarks)
        VALUES
            (p_ApplicationID, v_OldStatus, p_NewStatus,
             p_ChangedByType, p_ChangedByID, p_Remarks);
 
        INSERT INTO AuditTrail (ActorType, ActorID, Action, TargetTable, TargetID, Details)
        VALUES (p_ChangedByType, p_ChangedByID, 'STATUS_CHANGE', 'Applications',
                p_ApplicationID,
                CONCAT('Status: ', v_OldStatus, ' → ', p_NewStatus));
    END IF;
END$$
 
-- SP 3: Record Final Hiring Decision (HR Manager / Admin only)
CREATE PROCEDURE sp_RecordHiringDecision (
    IN p_ApplicationID INT,
    IN p_DecidedByID   INT,
    IN p_Decision      VARCHAR(20),
    IN p_Remarks       TEXT
)
BEGIN
    DECLARE v_RoleName VARCHAR(50);
 
    SELECT r.RoleName INTO v_RoleName
    FROM   Users u
    JOIN   Roles r ON u.RoleID = r.RoleID
    WHERE  u.UserID = p_DecidedByID;
 
    IF v_RoleName NOT IN ('HR Manager','Admin') THEN
        SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Only HR Manager or Admin can make the final hiring decision.';
    ELSE
        CALL sp_ChangeApplicationStatus(
            p_ApplicationID, p_Decision, v_RoleName, p_DecidedByID, p_Remarks);
 
        INSERT INTO HiringDecisions (ApplicationID, DecidedByUserID, Decision, Remarks)
        VALUES (p_ApplicationID, p_DecidedByID, p_Decision, p_Remarks)
        ON DUPLICATE KEY UPDATE
            Decision        = p_Decision,
            Remarks         = p_Remarks,
            DecidedByUserID = p_DecidedByID,
            DecidedAt       = NOW();
    END IF;
END$$
 
-- SP 4: Schedule an Interview (validates date is not in the past)
CREATE PROCEDURE sp_ScheduleInterview (
    IN p_ApplicationID     INT,
    IN p_InterviewTypeID   INT,
    IN p_InterviewerUserID INT,
    IN p_ScheduledDate     DATE,
    IN p_ScheduledTime     TIME,
    IN p_Mode              VARCHAR(20),
    IN p_Location          VARCHAR(255),
    IN p_MeetingLink       VARCHAR(500),
    IN p_CreatedByUserID   INT
)
BEGIN
    IF p_ScheduledDate < CURDATE() THEN
        SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Interview date cannot be in the past.';
    ELSE
        INSERT INTO InterviewSchedules
            (ApplicationID, InterviewTypeID, InterviewerUserID, ScheduledDate,
             ScheduledTime, Mode, Location, MeetingLink, Status, CreatedByUserID)
        VALUES
            (p_ApplicationID, p_InterviewTypeID, p_InterviewerUserID,
             p_ScheduledDate, p_ScheduledTime, p_Mode, p_Location,
             p_MeetingLink, 'Scheduled', p_CreatedByUserID);
 
        CALL sp_ChangeApplicationStatus(
            p_ApplicationID, 'For Interview',
            'HR Staff', p_CreatedByUserID, 'Interview scheduled.');
    END IF;
END$$
 
-- SP 5: Check for Duplicate Application
CREATE PROCEDURE sp_CheckDuplicateApplication (
    IN  p_ApplicantID INT,
    IN  p_VacancyID   INT,
    OUT p_IsDuplicate TINYINT
)
BEGIN
    SELECT COUNT(*) INTO p_IsDuplicate
    FROM   Applications
    WHERE  ApplicantID = p_ApplicantID
      AND  VacancyID   = p_VacancyID;
END$$
 
-- SP 6: Get Missing Document Count for an Application
CREATE PROCEDURE sp_GetMissingDocCount (
    IN p_ApplicationID INT
)
BEGIN
    SELECT COUNT(*) AS MissingCount
    FROM   vw_MissingDocuments
    WHERE  ApplicationID = p_ApplicationID;
END$$
 
DELIMITER ;
