# Chat-Application
Basic Chat Application C# WPF ,Web Service and SQL Server Database
Create a database CasaNetwork and tables as follows:

CREATE TABLE [dbo].[MessageBox](
	[Message] [ntext] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[FromUserName] [varchar](100) NOT NULL,
	[MessageFromName] [varchar](100) NOT NULL,
	[MessageToUserName] [varchar](100) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


CREATE TABLE [dbo].[UserDetails](
	[Name] [varchar](100) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](150) NOT NULL
) ON [PRIMARY]


Run AzureCloudService Project Seperately and copy the Url of service1.csv whether from a domain or from a localhost
Paste the url in MessagesClientWpfApp/ appconfig 

if you have any questions or Problems encounted, drop me line on 07umarjan@gmail.com
