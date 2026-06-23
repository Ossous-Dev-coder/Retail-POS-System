CREATE PROCEDURE SP_AddNewUser
(
    @firstName VARCHAR(50),
    @lastName VARCHAR(50),
    @phone VARCHAR(20) = NULL,
    @email VARCHAR(100),
    @passwordHash VARCHAR(255),
    @hashSalt VARCHAR(255),
    @permissions INT,
    @imagePath VARCHAR(300) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Users
    (
        firstName,
        lastName,
        phone,
        email,
        passwordHash,
        hashSalt,
        permissions,
        imagePath
    )
    VALUES
    (
        @firstName,
        @lastName,
        @phone,
        @email,
        @passwordHash,
        @hashSalt,
        @permissions,
        @imagePath
    );

    SELECT SCOPE_IDENTITY() AS UserId;
END
GO

--====================== Update User ============ /


CREATE PROCEDURE SP_UpdateUser
(
    @id INT,
    @firstName VARCHAR(50),
    @lastName VARCHAR(50),
    @phone VARCHAR(20) = NULL,
    @email VARCHAR(100),
    @permissions INT,
    @imagePath VARCHAR(300) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET
        firstName = @firstName,
        lastName = @lastName,
        phone = @phone,
        email = @email,
        permissions = @permissions,
        imagePath = @imagePath,
        updatedAt = GETDATE()
    WHERE id = @id;

    RETURN @@ROWCOUNT;
END
GO

--========================== Activation / Deactivate ================= /

CREATE PROCEDURE SP_ChangeActivationStatus
(
    @id INT,
	@actvationStatus BIT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users SET IsActive = @actvationStatus;

    RETURN @@ROWCOUNT;
END
GO

--================================= Get All Users ============= /

CREATE PROCEDURE SP_GetAllUsers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        id,
        firstName,
        lastName,
        phone,
        email,
        permissions,
        createdAt,
        updatedAt,
		IsActive,
        imagePath
    FROM Users
    ORDER BY id DESC;
END
GO

--================================== Get User by id ============== /

CREATE PROCEDURE SP_GetUserById
(
    @id INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        id,
        firstName,
        lastName,
        phone,
        email,
        permissions,
        createdAt,
        updatedAt,
		IsActive,
        imagePath
    FROM Users
    WHERE id = @id;
END
GO

--================= Is User Exists ========= /

CREATE PROCEDURE SP_IsUserExists
(
    @userId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 1
    FROM Users
    WHERE id = @userId;
END
GO