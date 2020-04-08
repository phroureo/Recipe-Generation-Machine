alter procedure dbo.sp_AddNewRecipe
@recipeName nvarchar(80)
, @recipeDesc nvarchar(1000)
, @recSource nvarchar(50)
, @status nvarchar(100) output
, @recID int output
AS


--find number of recipes with the exact same name (please note: this is only tracking exact names. Maybe we can 
--figure out something to find similar names later on 
DECLARE @sameNameRec int = (SELECT count(*) from recipe where recName = @recipeName)

BEGIN TRANSACTION InsertRecipeTransaction

INSERT INTO recipe (recName, recDescription, recSource)
values (@recipeName, @recipeDesc, @recSource)

IF @sameNameRec > 0 
BEGIN 
	ROLLBACK TRANSACTION InsertRecipeTransaction
	Set @recID = 0
END 
ELSE 
BEGIN 
	COMMIT TRANSACTION InsertRecipeTransaction
	Set @recID = @@IDENTITY
END 

Set @status = case when @sameNameRec = 1 then concat(@sameNameRec,' recipe with this name already exists! Are you sure you want to add it?')
				   when @sameNameRec > 1 then concat(@sameNameRec,' recipes with this name already exist! Are you sure you want to add it?') 
				   when @sameNameRec = 0 then 'Recipe added successfully.' 
				   END 

GO 