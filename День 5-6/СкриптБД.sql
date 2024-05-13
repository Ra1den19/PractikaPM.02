USE [MedicalLaboratory]
GO
/****** Object:  Table [db_owner].[Биоматериалы]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [db_owner].[Биоматериалы](
	[ID биоматериала] [int] IDENTITY(1,1) NOT NULL,
	[код пробирки] [int] NULL,
	[наименование] [nvarchar](50) NULL,
	[количество] [int] NULL,
	[ID пациента] [int] NULL,
	[услуги] [int] NULL,
 CONSTRAINT [PK_Биоматериалы] PRIMARY KEY CLUSTERED 
(
	[ID биоматериала] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Бухгалтер]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Бухгалтер](
	[ID бухгалтера] [int] IDENTITY(1,1) NOT NULL,
	[логин] [nvarchar](50) NULL,
	[пароль] [nvarchar](50) NULL,
	[ФИО] [nvarchar](50) NULL,
	[последняя дата входа] [date] NULL,
	[последнее время входа] [time](7) NULL,
	[набор услуг] [int] NULL,
	[выставленные счета страховым компаниям] [int] NULL,
 CONSTRAINT [PK_Бухгалтер] PRIMARY KEY CLUSTERED 
(
	[ID бухгалтера] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Данные лаборантов]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Данные лаборантов](
	[ID лаборанта] [int] IDENTITY(1,1) NOT NULL,
	[логин] [nvarchar](50) NULL,
	[пароль] [nvarchar](50) NULL,
	[роль] [nvarchar](50) NULL,
	[ФИО] [nvarchar](50) NULL,
	[последняя дата входа] [date] NULL,
	[последнее время входа] [time](7) NULL,
	[набор оказываемых услуг] [int] NULL,
 CONSTRAINT [PK_Данные лаборантов] PRIMARY KEY CLUSTERED 
(
	[ID лаборанта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Данные о работе анализатора]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Данные о работе анализатора](
	[ID анализатора] [int] IDENTITY(1,1) NOT NULL,
	[дата поступления заказа на анализатор] [date] NULL,
	[время поступления заказа на анализатор] [time](7) NULL,
	[дата выполнения услуги на анализаторе] [date] NULL,
	[время выполнения услуги на анализаторе] [time](7) NULL,
	[кем выполнена услуга] [int] NULL,
	[ID биоматериала] [int] NULL,
 CONSTRAINT [PK_Данные о работе анализатора] PRIMARY KEY CLUSTERED 
(
	[ID анализатора] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Данные о страховых компаниях]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Данные о страховых компаниях](
	[ID страховой компании] [int] IDENTITY(1,1) NOT NULL,
	[название страховой компании] [nvarchar](50) NULL,
	[адрес компании] [nvarchar](50) NULL,
	[ИНН] [bigint] NULL,
	[р/с] [int] NULL,
	[БИК] [int] NULL,
 CONSTRAINT [PK_Данные о страховых компаниях] PRIMARY KEY CLUSTERED 
(
	[ID страховой компании] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Данные пациентов]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Данные пациентов](
	[ID пациента] [int] IDENTITY(1,1) NOT NULL,
	[логин] [nvarchar](50) NULL,
	[пароль] [nvarchar](50) NULL,
	[ФИО] [nvarchar](50) NULL,
	[дата рождения] [date] NULL,
	[серия паспорта] [int] NULL,
	[номер паспорта] [int] NULL,
	[телефон] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[номер страхового полиса] [int] NULL,
	[тип страхового полиса] [nvarchar](50) NULL,
	[страховая компания] [int] NULL,
 CONSTRAINT [PK_Данные пациентов] PRIMARY KEY CLUSTERED 
(
	[ID пациента] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Заказы]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказы](
	[ID заказа] [int] IDENTITY(1,1) NOT NULL,
	[Наименование заказа] [nvarchar](50) NULL,
	[дата создания] [date] NULL,
	[статус заказа] [nvarchar](50) NULL,
	[услуги] [int] NULL,
	[время выполнения заказа] [int] NULL,
	[ID пациента] [int] NULL,
 CONSTRAINT [PK_Заказы] PRIMARY KEY CLUSTERED 
(
	[ID заказа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Оказанные услуги]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Оказанные услуги](
	[ID услуги] [int] IDENTITY(1,1) NOT NULL,
	[ID заказа] [int] NULL,
	[дата оказания услуги] [date] NULL,
	[кем оказана услуга] [int] NULL,
	[анализатор оказанной услуги] [int] NULL,
 CONSTRAINT [PK_Оказанные услуги] PRIMARY KEY CLUSTERED 
(
	[ID услуги] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Счета страховых компаний]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Счета страховых компаний](
	[ID счета] [int] IDENTITY(1,1) NOT NULL,
	[ID страховой компании] [int] NULL,
	[ID пациента] [int] NULL,
	[ID услуги] [int] NULL,
 CONSTRAINT [PK_Счета страховых компаний] PRIMARY KEY CLUSTERED 
(
	[ID счета] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Услуги лаборатории]    Script Date: 13.05.2024 15:06:03 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Услуги лаборатории](
	[ID услуги лаборатории] [int] IDENTITY(1,1) NOT NULL,
	[наименование] [nvarchar](50) NULL,
	[стоимость] [money] NULL,
	[срок выполнения] [int] NULL,
	[статус услуги] [nvarchar](50) NULL,
	[среднее отклонение] [int] NULL,
 CONSTRAINT [PK_Услуги лаборатории] PRIMARY KEY CLUSTERED 
(
	[ID услуги лаборатории] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [db_owner].[Биоматериалы]  WITH CHECK ADD  CONSTRAINT [FK_Биоматериалы_Данные пациентов] FOREIGN KEY([ID пациента])
REFERENCES [dbo].[Данные пациентов] ([ID пациента])
GO
ALTER TABLE [db_owner].[Биоматериалы] CHECK CONSTRAINT [FK_Биоматериалы_Данные пациентов]
GO
ALTER TABLE [db_owner].[Биоматериалы]  WITH CHECK ADD  CONSTRAINT [FK_Биоматериалы_Услуги лаборатории] FOREIGN KEY([услуги])
REFERENCES [dbo].[Услуги лаборатории] ([ID услуги лаборатории])
GO
ALTER TABLE [db_owner].[Биоматериалы] CHECK CONSTRAINT [FK_Биоматериалы_Услуги лаборатории]
GO
ALTER TABLE [dbo].[Бухгалтер]  WITH CHECK ADD  CONSTRAINT [FK_Бухгалтер_Услуги лаборатории] FOREIGN KEY([набор услуг])
REFERENCES [dbo].[Услуги лаборатории] ([ID услуги лаборатории])
GO
ALTER TABLE [dbo].[Бухгалтер] CHECK CONSTRAINT [FK_Бухгалтер_Услуги лаборатории]
GO
ALTER TABLE [dbo].[Данные лаборантов]  WITH CHECK ADD  CONSTRAINT [FK_Данные лаборантов_Услуги лаборатории] FOREIGN KEY([набор оказываемых услуг])
REFERENCES [dbo].[Услуги лаборатории] ([ID услуги лаборатории])
GO
ALTER TABLE [dbo].[Данные лаборантов] CHECK CONSTRAINT [FK_Данные лаборантов_Услуги лаборатории]
GO
ALTER TABLE [dbo].[Данные о работе анализатора]  WITH CHECK ADD  CONSTRAINT [FK_Данные о работе анализатора_Биоматериалы] FOREIGN KEY([ID биоматериала])
REFERENCES [db_owner].[Биоматериалы] ([ID биоматериала])
GO
ALTER TABLE [dbo].[Данные о работе анализатора] CHECK CONSTRAINT [FK_Данные о работе анализатора_Биоматериалы]
GO
ALTER TABLE [dbo].[Данные о работе анализатора]  WITH CHECK ADD  CONSTRAINT [FK_Данные о работе анализатора_Данные лаборантов] FOREIGN KEY([кем выполнена услуга])
REFERENCES [dbo].[Данные лаборантов] ([ID лаборанта])
GO
ALTER TABLE [dbo].[Данные о работе анализатора] CHECK CONSTRAINT [FK_Данные о работе анализатора_Данные лаборантов]
GO
ALTER TABLE [dbo].[Данные пациентов]  WITH CHECK ADD  CONSTRAINT [FK_Данные пациентов_Данные о страховых компаниях] FOREIGN KEY([страховая компания])
REFERENCES [dbo].[Данные о страховых компаниях] ([ID страховой компании])
GO
ALTER TABLE [dbo].[Данные пациентов] CHECK CONSTRAINT [FK_Данные пациентов_Данные о страховых компаниях]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_Данные пациентов] FOREIGN KEY([ID пациента])
REFERENCES [dbo].[Данные пациентов] ([ID пациента])
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_Данные пациентов]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_Услуги лаборатории1] FOREIGN KEY([услуги])
REFERENCES [dbo].[Услуги лаборатории] ([ID услуги лаборатории])
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_Услуги лаборатории1]
GO
ALTER TABLE [dbo].[Оказанные услуги]  WITH CHECK ADD  CONSTRAINT [FK_Оказанные услуги_Данные лаборантов] FOREIGN KEY([кем оказана услуга])
REFERENCES [dbo].[Данные лаборантов] ([ID лаборанта])
GO
ALTER TABLE [dbo].[Оказанные услуги] CHECK CONSTRAINT [FK_Оказанные услуги_Данные лаборантов]
GO
ALTER TABLE [dbo].[Оказанные услуги]  WITH CHECK ADD  CONSTRAINT [FK_Оказанные услуги_Заказы] FOREIGN KEY([ID заказа])
REFERENCES [dbo].[Заказы] ([ID заказа])
GO
ALTER TABLE [dbo].[Оказанные услуги] CHECK CONSTRAINT [FK_Оказанные услуги_Заказы]
GO
ALTER TABLE [dbo].[Счета страховых компаний]  WITH CHECK ADD  CONSTRAINT [FK_Счета страховых компаний_Данные о страховых компаниях] FOREIGN KEY([ID страховой компании])
REFERENCES [dbo].[Данные о страховых компаниях] ([ID страховой компании])
GO
ALTER TABLE [dbo].[Счета страховых компаний] CHECK CONSTRAINT [FK_Счета страховых компаний_Данные о страховых компаниях]
GO
ALTER TABLE [dbo].[Счета страховых компаний]  WITH CHECK ADD  CONSTRAINT [FK_Счета страховых компаний_Данные пациентов] FOREIGN KEY([ID пациента])
REFERENCES [dbo].[Данные пациентов] ([ID пациента])
GO
ALTER TABLE [dbo].[Счета страховых компаний] CHECK CONSTRAINT [FK_Счета страховых компаний_Данные пациентов]
GO
ALTER TABLE [dbo].[Счета страховых компаний]  WITH CHECK ADD  CONSTRAINT [FK_Счета страховых компаний_Оказанные услуги] FOREIGN KEY([ID услуги])
REFERENCES [dbo].[Оказанные услуги] ([ID услуги])
GO
ALTER TABLE [dbo].[Счета страховых компаний] CHECK CONSTRAINT [FK_Счета страховых компаний_Оказанные услуги]
GO
