ALTER PROCEDURE SP_AddNewUser
(
    @firstName VARCHAR(50),
    @lastName VARCHAR(50),
    @phone VARCHAR(20) = NULL,
    @email VARCHAR(100),
    @passwordHash VARCHAR(255),
    @hashSalt VARCHAR(255),
    @role_id INT,
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
        role_id,
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
        @role_id,
        @imagePath
    );

    SELECT SCOPE_IDENTITY() AS UserId;
END
GO

--====================== Update User ============ /


ALTER PROCEDURE SP_UpdateUser
(
    @id INT,
    @firstName VARCHAR(50),
    @lastName VARCHAR(50),
    @phone VARCHAR(20) = NULL,
    @email VARCHAR(100),
    @role_id INT,
    @imagePath VARCHAR(300) = NULL
)
AS
BEGIN

    UPDATE Users
    SET
        firstName = @firstName,
        lastName = @lastName,
        phone = @phone,
        email = @email,
        role_id = @role_id,
        imagePath = @imagePath,
        updatedAt = GETDATE()
    WHERE id = @id;

    RETURN @@ROWCOUNT;
END
GO

--========================== Activation / Deactivate ================= /

ALTER PROCEDURE SP_ChangeActivationStatus
(
    @id INT,
	@activationStatus BIT
)
AS
BEGIN

    UPDATE Users SET IsActive = @activationStatus WHERE id = @id;

    RETURN @@ROWCOUNT;
END
GO

--================================= Get All Users ============= /

ALTER PROCEDURE SP_GetAllUsers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        u.id,
        u.firstName,
        u.lastName,
        u.phone,
        u.email,
        u.role_id,
		r.Name AS roleName,
        u.createdAt,
        u.updatedAt,
		u.IsActive,
        u.imagePath
    FROM Users u JOIN Roles r ON u.role_id = r.id
    ORDER BY id DESC;
END
GO

--================================== Get User by id ============== /

ALTER PROCEDURE SP_GetUserById
(
    @id INT
)
AS
BEGIN
    SET NOCOUNT ON;

     SELECT
        u.id,
        u.firstName,
        u.lastName,
        u.phone,
        u.email,
        u.role_id,
		r.Name AS roleName,
        u.createdAt,
        u.updatedAt,
		u.IsActive,
        u.imagePath
    FROM Users u JOIN Roles r ON u.role_id = r.id
    WHERE u.id = @id;
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