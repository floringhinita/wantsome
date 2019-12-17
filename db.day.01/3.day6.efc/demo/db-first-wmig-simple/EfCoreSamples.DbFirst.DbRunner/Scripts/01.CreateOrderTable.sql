CREATE TABLE [dbo].[Orders] (
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
	(
		[OrderId] ASC
	) ON [PRIMARY]
) ON [PRIMARY]
GO
