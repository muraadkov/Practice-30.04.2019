create table [dbo].[News](
Id uniqueidentifier primary key,
Author nvarchar(50) not null,
Text nvarchar(max) not null,
PublishDate datetime not null,
)
create table [dbo].[Comments](
Id uniqueidentifier primary key,
Author nvarchar(50) not null,
Text nvarchar(max) not null,
CommentDate datetime not null,
IdNew uniqueidentifier not null
constraint [FK_Comments_ToNews] foreign key (IdNew) references[News]([Id])
)
