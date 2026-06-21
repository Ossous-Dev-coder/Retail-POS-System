
ALTER PROCEDURE SP_addNewMovement (@product_id INT, @movementType_id INT, @quantity DECIMAL(11,2) ) AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO StockMovements (product_id, movementType_id, quantity)
	VALUES (@product_id, @movementType_id, @quantity)

	SELECT SCOPE_IDENTITY() AS NewMovementId

END

--============================================
GO


ALTER PROCEDURE SP_getMovements
(
    @pageNumber INT,
    @rowsPerPage INT,
    @fromDate DATETIME2 = NULL,
    @toDate DATETIME2 = NULL,
    @product_id INT = NULL,
    @movementType_id INT = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    IF @pageNumber <= 0 SET @pageNumber = 1;
    IF @rowsPerPage <= 0 SET @rowsPerPage = 10;


    IF (@fromDate IS NULL AND @toDate IS NOT NULL)
        THROW 50001, 'From date is required when To date is provided', 1;

    IF (@fromDate IS NOT NULL AND @toDate IS NULL)
        THROW 50002, 'To date is required when From date is provided', 1;

    IF (@fromDate IS NOT NULL AND @toDate IS NOT NULL AND @toDate < @fromDate)
        THROW 50003, 'Invalid date range', 1;

    IF @product_id IS NOT NULL AND @product_id <= 0
        THROW 50004, 'Invalid product Id', 1;

    IF @movementType_id IS NOT NULL AND @movementType_id <= 0
        THROW 50005, 'Invalid movementType Id', 1;

    DECLARE @offset INT = (@pageNumber - 1) * @rowsPerPage;

    SELECT
        sm.id,
        sm.createdAt,
        sm.quantity,

        sm.product_id,
        p.name,

        sm.movementType_id,
        mt.name
    FROM StockMovements sm
    INNER JOIN Products p ON p.id = sm.product_id
    INNER JOIN MovementTypes mt ON mt.id = sm.movementType_id

    WHERE
        (@fromDate IS NULL OR sm.createdAt >= @fromDate)
        AND (@toDate IS NULL OR sm.createdAt < DATEADD(DAY, 1, @toDate))
        AND (@product_id IS NULL OR sm.product_id = @product_id)
        AND (@movementType_id IS NULL OR sm.movementType_id = @movementType_id)

    ORDER BY sm.createdAt DESC, sm.id DESC

    OFFSET @offset ROWS
    FETCH NEXT @rowsPerPage ROWS ONLY;
END;

