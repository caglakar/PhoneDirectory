IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Contacts] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Firm] nvarchar(50) NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ContactDetails] (
    [Id] uniqueidentifier NOT NULL,
    [Type] int NOT NULL,
    [ContactDetailInfo] nvarchar(max) NULL,
    [ContactId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ContactDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ContactDetails_Contacts_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Contacts] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ContactDetails_ContactId] ON [ContactDetails] ([ContactId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220217143032_CreateDb', N'5.0.14');
GO

COMMIT;
GO

