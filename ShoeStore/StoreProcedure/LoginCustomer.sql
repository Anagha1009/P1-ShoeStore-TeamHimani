USE [ShoeProject]
GO

/****** Object:  StoredProcedure [dbo].[stp_LoginUser]    Script Date: 9/13/2021 12:38:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stp_LoginUser] 
	@Username		varchar(10),
	@Password		varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT username,[password] from tbl_users where username= @Username and [password]=@Password
END
GO

