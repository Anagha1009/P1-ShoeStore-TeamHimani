USE [ShoeProject]
GO

/****** Object:  StoredProcedure [dbo].[stp_InsertData]    Script Date: 9/13/2021 12:38:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stp_InsertData]
	@Name			varchar(50),
	@Email			varchar(250),
	@Contact		varchar(10),
	@Username		varchar(10),
	@Password		varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @NewUserId	int

	Insert into tbl_users
						(
							[role],
							username,
							[password]
						) 
				values
						(
							'Customer',
							@Username,
							@Password
						)
	Select @NewUserId=SCOPE_IDENTITY()

	Insert into tbl_customer
						(
							customer_name,
							users_id,
							customer_email,
							customer_contact
						) 
				values
						(
							@Name,
							@NewUserId,
							@Email,
							@Contact
						)
END
GO

