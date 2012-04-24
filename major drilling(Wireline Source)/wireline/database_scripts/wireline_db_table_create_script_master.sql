IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'wireline_user')
CREATE USER [wireline_user] FOR LOGIN [wireline_user] WITH DEFAULT_SCHEMA=[dbo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[country]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[country](
	[country] [varchar](30) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wireline_monitor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[wireline_monitor](
	[rig_id] [char](10) NOT NULL,
	[country] [varchar](30) NULL,
	[opt_sp] [numeric](18, 0) NULL,
	[opt_frc] [numeric](18, 0) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[link_lookup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[link_lookup](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[msg_type] [int] NOT NULL,
	[msg] [varchar](500) NULL,
	[link] [varchar](500) NULL,
	[pin_type] [char](30) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wireline_data_pin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[wireline_data_pin](
	[job_no] [char](10) NOT NULL,
	[hole_id] [varchar](50) NOT NULL,
	[rig_id] [char](10) NOT NULL,
	[gps_long] [char](12) NOT NULL,
	[gps_lat] [char](12) NOT NULL,
	[time_start] [datetime] NOT NULL,
	[avg_sp] [numeric](18, 0) NULL,
	[avg_fc] [numeric](18, 0) NULL,
	[msg_type] [int] NULL,
	[msg] [varchar](500) NULL,
	[link] [varchar](500) NULL,
	[pin_type] [nchar](20) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_wireline_data_pin_1] PRIMARY KEY CLUSTERED 
(
	[hole_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wireline_data_new_format]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[wireline_data_new_format](
	[job_no] [char](10) NOT NULL,
	[hole_id] [char](10) NOT NULL,
	[rig_id] [char](10) NOT NULL,
	[gps_long] [char](12) NOT NULL,
	[gps_lat] [char](12) NOT NULL,
	[wireline_rate] [numeric](18, 0) NOT NULL,
	[drilling_rate] [numeric](18, 0) NOT NULL,
	[hole_size] [char](1) NOT NULL,
	[hole_inclination] [numeric](18, 0) NOT NULL,
	[drill_rods] [varchar](30) NOT NULL,
	[tube_head] [varchar](30) NOT NULL,
	[core_barrel_len] [varchar](30) NOT NULL,
	[os_size] [char](1) NOT NULL,
	[core_or] [char](1) NOT NULL,
	[core_or_bypass] [char](1) NOT NULL,
	[water_depth] [numeric](18, 0) NOT NULL,
	[md1_ver] [numeric](18, 0) NOT NULL,
	[rd3_ser] [char](10) NOT NULL,
	[metric_english] [char](1) NOT NULL,
	[wl_ud] [varchar](3) NOT NULL,
	[time_start] [datetime] NOT NULL,
	[start_point] [numeric](18, 0) NOT NULL,
	[frc_interval] [numeric](18, 0) NOT NULL,
	[sp_interval] [numeric](18, 0) NOT NULL,
	[pk_frc] [numeric](18, 0) NOT NULL,
	[pk_dep] [numeric](18, 0) NOT NULL,
	[dist] [numeric](18, 0) NULL,
	[time_end] [datetime] NOT NULL,
	[run_no] [numeric](18, 0) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[real_depth] [numeric](18, 0) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[martin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[martin](
	[id] [numeric](18, 0) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wireline_data]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[wireline_data](
	[job_no] [char](10) NOT NULL,
	[hole_id] [char](10) NOT NULL,
	[rig_id] [char](10) NOT NULL,
	[gps_long] [char](12) NOT NULL,
	[gps_lat] [char](12) NOT NULL,
	[wireline_rate] [numeric](18, 0) NOT NULL,
	[drilling_rate] [numeric](18, 0) NOT NULL,
	[hole_size] [char](1) NOT NULL,
	[hole_inclination] [numeric](18, 0) NOT NULL,
	[drill_rods] [varchar](30) NOT NULL,
	[tube_head] [varchar](30) NOT NULL,
	[core_barrel_len] [varchar](30) NOT NULL,
	[os_size] [char](1) NOT NULL,
	[core_or] [char](1) NOT NULL,
	[core_or_bypass] [char](1) NOT NULL,
	[water_depth] [numeric](18, 0) NOT NULL,
	[md1_ver] [numeric](18, 0) NOT NULL,
	[rd3_ser] [char](10) NOT NULL,
	[metric_english] [char](1) NOT NULL,
	[wl_ud] [varchar](3) NOT NULL,
	[time_start] [datetime] NOT NULL,
	[date] [datetime] NOT NULL,
	[frc_interval] [numeric](18, 0) NOT NULL,
	[sp_interval] [numeric](18, 0) NOT NULL,
	[pk_frc] [numeric](18, 0) NOT NULL,
	[pk_dep] [numeric](18, 0) NOT NULL,
	[dist] [numeric](18, 0) NULL,
	[time_end] [datetime] NOT NULL,
	[run_no] [numeric](18, 0) NOT NULL,
	[sr_dep] [numeric](18, 0) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[new_rig_id]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[new_rig_id]
AS
SELECT DISTINCT rig_id AS rig
FROM         dbo.wireline_data_new_format
WHERE     (NOT EXISTS
                          (SELECT     rig_id AS rig
                            FROM          dbo.wireline_monitor
                            WHERE      (dbo.wireline_data_new_format.rig_id = rig_id)))
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[avg_sp_fc]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[avg_sp_fc](@hole char(10), @datest datetime)
AS
declare @rig_mon CHAR(10)
declare @sp NUMERIC(18,1)
declare @fc NUMERIC(18,1)
declare @optsp NUMERIC(18,1)
declare @optfrc NUMERIC(18,1)
declare @cty VARCHAR(30)
declare @msg VARCHAR(500)
declare @link VARCHAR(500)
declare @pintype char(20)
declare @msgtype int

BEGIN TRY

		SELECT @sp = avg(sp_interval)
		FROM      dbo.wireline_data_new_format
		WHERE     hole_id = @hole
		and time_start >= @datest;	
		
		SELECT @fc = avg(frc_interval)
		FROM      dbo.wireline_data_new_format
		WHERE     hole_id = @hole
		and time_start >= @datest;

        SELECT @rig_mon = rig_id, @cty = country, @optsp = opt_sp, @optfrc = opt_frc
		FROM dbo.wireline_monitor
        WHERE rig_id = (select distinct(rig_id) from wireline_data_new_format where hole_id = @hole)

        if @sp < @optsp AND @fc > @optfrc set @msgtype = 4;
		if @sp > @optsp and @fc < @optfrc set @msgtype = 1;
        if @sp < @optsp and @fc < @optfrc set @msgtype = 2;
        if @fc > @optfrc and @sp > @optsp set @msgtype = 3;
		if @cty is null or @optsp is null or @optfrc is null set @msgtype = 5;

		SELECT @msg=msg, @link=link, @pintype=pin_type
		FROM dbo.link_lookup
        WHERE msg_type = @msgtype
       
          BEGIN TRY
            UPDATE wireline_data_pin
			SET avg_sp=@sp,avg_fc=@fc,msg_type=@msgtype,msg=@msg,link=@link,pin_type=@pintype 
            WHERE hole_id = @hole			
		  END TRY			
		  BEGIN CATCH
			RETURN 0  		
			PRINT ''ERROR Updating Pin Table Message for type: '' + @msgtype
		  END CATCH

END TRY        
		
BEGIN CATCH

	DECLARE @ErrorMessage NVARCHAR(4000);
    	SELECT @ErrorMessage = ERROR_MESSAGE();
	RAISERROR (@ErrorMessage, 10, 1);
	return 0  		
	PRINT ''ERROR Evaluating Speed/Force Levels: '' + ERROR_MESSAGE()

		      
END CATCH
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[new_rigs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author: Damian Puiia
-- Create date: April 18, 2008
-- Description:	Stored procedure used to add new 
-- rigs to the wireline_monitor table during the 
-- data load.
-- =============================================
--CREATE OR 
CREATE PROCEDURE [dbo].[new_rigs] AS
-- variable to retain the rig id from the new_rig_id view
	 DECLARE @rig nchar(10)
BEGIN 
	  BEGIN TRY
        DECLARE rig_cursor CURSOR
		FOR Select rig from dbo.new_rig_id

      OPEN rig_cursor
			FETCH NEXT FROM rig_cursor
			INTO @rig
            WHILE @@FETCH_STATUS = 0
		    BEGIN  
			IF @rig IS NOT NULL
			   BEGIN TRY
				INSERT INTO wireline_monitor VALUES (@rig, null, null, null)
               END TRY
               BEGIN CATCH
				PRINT ''ERROR INSERTING RIG MONITOR for RIG: '' + @rig
			   END CATCH
            FETCH NEXT FROM rig_cursor
			INTO @rig
			END
 
      CLOSE rig_cursor
		DEALLOCATE rig_cursor
  END TRY
               BEGIN CATCH
				PRINT ''ERROR INSERTING RIG MONITOR ''
			   END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[wireline_up]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[wireline_up]
AS
SELECT d.hole_id, p.time_start, d.sp_interval, d.pk_dep 
FROM   dbo.wireline_data_new_format d, dbo.wireline_data_pin p
WHERE d.wl_ud = ''UP''
AND p.hole_id = d.hole_id
And d.time_start >= p.time_start
GROUP BY d.hole_id, p.time_start, d.sp_interval, d.pk_dep
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[wireline_dn]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[wireline_dn]
AS
SELECT d.hole_id, p.time_start, d.sp_interval, d.pk_dep 
FROM   dbo.wireline_data_new_format d, dbo.wireline_data_pin p
WHERE d.wl_ud = ''DN''
AND p.hole_id = d.hole_id
And d.time_start >= p.time_start
GROUP BY d.hole_id, p.time_start, d.sp_interval, d.pk_dep
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[wireline_min_max_new_format]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[wireline_min_max_new_format]
AS
SELECT     hole_id, date, MIN(avg_test) AS min_run, MAX(avg_test) AS max_run
FROM         (SELECT     d.run_no, p.hole_id, CONVERT(datetime, p.time_start, 112) AS date, AVG(d.sp_interval) AS avg_test
              FROM          dbo.wireline_data_new_format d, dbo.wireline_data_pin p
			  where p.hole_id = d.hole_id
              GROUP BY d.run_no, p.hole_id, p.time_start) AS wireline_averages
GROUP BY hole_id, date' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[new_pin]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[new_pin]
AS
SELECT DISTINCT hole_id AS pin
FROM         dbo.wireline_data_new_format
WHERE     hole_id NOT IN
                          (SELECT     hole_id AS pin
                            FROM          dbo.wireline_data_pin )
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[wireline_min_max]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[wireline_min_max]
AS
SELECT     hole_id, date, MIN(avg_test) AS min_run, MAX(avg_test) AS max_run
FROM         (SELECT     d.run_no, p.hole_id, CONVERT(datetime, p.time_start, 112) AS date, AVG(d.sp_interval) AS avg_test
              FROM          dbo.wireline_data d, dbo.wireline_data_pin p
			  where p.hole_id = d.hole_id
              GROUP BY d.run_no, p.hole_id, p.time_start) AS wireline_averages
GROUP BY hole_id, date
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wireline_load_new_format]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Martin Poirier (BSI)
-- Create date: Oct 28, 2008
-- main loading process for wireline data (NEW FORMAT)
-- =============================================

CREATE PROCEDURE [dbo].[wireline_load_new_format](@job char(10),@hole char(10), @rig char(10), @long char(12),
@lat char(12), @wl_rate char(4), @drl_rate char(4), @hl_size char(1), @hl_inc char(3),
@drl_rods varchar(30), @tube_head varchar(30), @c_brl_len varchar(30), @os_size char(1), @core_or char(1),
@core_or_by char(1), @water_dep char(10), @md1_ver char(10), @rd3_ser char(10), @me char(1),
@w_ud char(3), @start varchar(50), @start_point char(10), @force char(10), @speed char(10), @real_depth char(10),
@pk_frc char(10), @pk_dep char(10), @dist char(10), @end varchar(50), @run char(10) ) AS

BEGIN TRY

	INSERT INTO wireline_data_new_format (job_no, hole_id, rig_id, gps_long, gps_lat, wireline_rate, drilling_rate,
	hole_size, hole_inclination, drill_rods, tube_head, core_barrel_len, os_size, core_or, core_or_bypass, water_depth, md1_ver, rd3_ser, 
	metric_english, wl_ud, time_start, start_point, frc_interval, sp_interval, real_depth, pk_frc, pk_dep, dist, time_end, run_no)
	VALUES (@job, @hole, @rig, @long, @lat, CAST(@wl_rate AS NUMERIC(18,0)), CAST(@drl_rate AS NUMERIC(18,0)),
        @hl_size, CAST(@hl_inc AS NUMERIC(18,0)), @drl_rods, @tube_head, @c_brl_len, @os_size, @core_or, @core_or_by, 
        CAST(@water_dep AS NUMERIC(18,0)), @md1_ver, @rd3_ser, @me, @w_ud, CAST(@start AS DATETIME), 
		CAST(@start_point AS NUMERIC(18,0)), CAST(@force AS NUMERIC(18,0)), CAST(@speed AS NUMERIC(18,1)), CAST(@real_depth AS NUMERIC(18,0)), 
		CAST(@pk_frc AS NUMERIC(18,0)), CAST(@pk_dep AS NUMERIC(18,0)), CAST(@dist AS NUMERIC(18,0)), 
		CAST(@end AS DATETIME), CAST(@run AS NUMERIC(18,0)))
 
		return 1
END TRY        
		
BEGIN CATCH

	DECLARE @ErrorMessage NVARCHAR(4000);
    	SELECT @ErrorMessage = ERROR_MESSAGE();
	RAISERROR (@ErrorMessage, 10, 1);
	return 0  		
	PRINT ''ERROR INSERTING WIRELINE DATA (NEW FORMAT) for Hole: '' + @hole + ''Run No: '' + @run + ''Depth: '' + @real_depth + '' '' + ERROR_MESSAGE()

		      
END CATCH
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[conv_up_down_new_format]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author: Damian Puiia
-- Create date: May 12, 2008
-- Description:	Stored procedure used to  
-- convert the wireline direction display data 
-- to conform to the custoemr preference.
-- =============================================
CREATE PROCEDURE [dbo].[conv_up_down_new_format] AS
     
BEGIN	
    BEGIN TRY
	--Convert wireline direction display data
    UPDATE wireline_data_new_format set wl_ud = ''UP''
	WHERE wl_ud = ''wu'';

	UPDATE wireline_data_new_format set wl_ud = ''DN''
	WHERE wl_ud = ''wd'';
  END TRY
    BEGIN CATCH
	PRINT ''ERROR Updating UP/DN values''
	END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[new_start_date_new_format]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[new_start_date_new_format]
AS
SELECT max(time_start) AS start_time, hole_id as hole
FROM      dbo.wireline_data_new_format
WHERE     run_no = 1
group by hole_id



' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[max_end_date_new_format]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[max_end_date_new_format]
AS
Select hole_id as hole, MAX(time_end) as time_end 
from wireline_data_new_format 
group by hole_id


' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wireline_load]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author: Damian Puiia
-- Create date: July 03, 2008
-- main loading process for wireline data
-- =============================================
CREATE PROCEDURE [dbo].[wireline_load](@job char(10),@hole char(10), @rig char(10), @long char(12),
@lat char(12), @wl_rate char(4), @drl_rate char(4), @hl_size char(1), @hl_inc char(3),
@drl_rods varchar(30), @tube_head varchar(30), @c_brl_len varchar(30), @os_size char(1), @core_or char(1),
@core_or_by char(1), @water_dep char(10), @md1_ver char(10), @rd3_ser char(10), @me char(1),
@w_ud char(3), @start varchar(50), @date varchar(50), @force char(10), @speed char(10),
@pk_frc char(10), @pk_dep char(10), @dist char(10), @end varchar(50), @run char(10),
@sr_dep char(10)) AS

Declare @sdate as varchar(30)
Declare @sedate as varchar(30)

BEGIN TRY
        --concatenate the start date with the start time
        Set @sdate = @date+'' ''+@start
        set @sedate = @date+'' ''+@end       
        	  
	INSERT INTO wireline_data (job_no, hole_id, rig_id, gps_long, gps_lat, wireline_rate, drilling_rate,
	hole_size, hole_inclination, drill_rods, tube_head, core_barrel_len, os_size, core_or, core_or_bypass,
	water_depth, md1_ver, rd3_ser, metric_english, wl_ud, time_start, date, frc_interval, sp_interval, pk_frc,
	pk_dep, dist, time_end, run_no, sr_dep )
	VALUES (@job, @hole, @rig, @long, @lat, CAST(@wl_rate AS NUMERIC(18,0)), CAST(@drl_rate AS NUMERIC(18,0)),
        @hl_size, CAST(@hl_inc AS NUMERIC(18,0)), @drl_rods, @tube_head, @c_brl_len, @os_size, @core_or, @core_or_by, 
        CAST(@water_dep AS NUMERIC(18,0)), @md1_ver, @rd3_ser, @me, 
        @w_ud, CAST(@sdate AS DATETIME), CAST(@date AS DATETIME), CAST(@force AS NUMERIC(18,0)), CAST(@speed AS NUMERIC(18,1)),
        CAST(@pk_frc AS NUMERIC(18,0)), CAST(@pk_dep AS NUMERIC(18,0)), CAST(@dist AS NUMERIC(18,0)), 
        CAST(@sedate AS DATETIME), CAST(@run AS NUMERIC(18,0)), CAST(@sr_dep AS NUMERIC(18,0))) 

		return 1
END TRY        
		
BEGIN CATCH

	DECLARE @ErrorMessage NVARCHAR(4000);
    	SELECT @ErrorMessage = ERROR_MESSAGE();
	RAISERROR (@ErrorMessage, 10, 1);
	return 0  		
	PRINT ''ERROR INSERTING WIRELINE DATA for Hole: '' + @hole + ''Run No: '' + @run + ''Depth: '' + @sr_dep + '' '' + ERROR_MESSAGE()

		      
END CATCH
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[new_start_date]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[new_start_date]
AS
SELECT max(time_start) AS start_time, hole_id as hole
FROM      dbo.wireline_data
WHERE     run_no = 1
group by hole_id



' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[max_end_date]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[max_end_date]
AS
Select hole_id as hole, MAX(time_end) as time_end 
from wireline_data 
group by hole_id


' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[conv_up_down]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author: Damian Puiia
-- Create date: May 12, 2008
-- Description:	Stored procedure used to  
-- convert the wireline direction display data 
-- to conform to the custoemr preference.
-- =============================================
CREATE PROCEDURE [dbo].[conv_up_down] AS
     
BEGIN	
    BEGIN TRY
	--Convert wireline direction display data
    UPDATE wireline_data set wl_ud = ''UP''
	WHERE wl_ud = ''wu'';

	UPDATE wireline_data set wl_ud = ''DN''
	WHERE wl_ud = ''wd'';
  END TRY
    BEGIN CATCH
	PRINT ''ERROR Updating UP/DN values''
	END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[new_pins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author: Damian Puiia
-- Create date: June 05, 2008
-- Description:	Stored procedure used to add new 
-- pins to the wireline_data_pin table during the 
-- data load.
-- =============================================
--CREATE OR 
CREATE PROCEDURE [dbo].[new_pins] AS
-- variable to retain the rig id form the new_rig_id view
	 DECLARE @pin nchar(10)
     DECLARE @job nchar(10)
     DECLARE @hole nchar(10)
     DECLARE @rig nchar(10)
     DECLARE @long nchar(10)
     DECLARE @lat nchar(10)
     DECLARE @time datetime
     
BEGIN	
	  BEGIN TRY
        DECLARE pin_cursor CURSOR
		FOR SELECT DISTINCT n.pin, w.job_no, w.hole_id, w.rig_id, w.gps_long, w.gps_lat, w.time_start 
        FROM dbo.new_pin n, wireline_data_new_format w
        WHERE n.pin = w.hole_id
		AND w.run_no = 1;
        OPEN pin_cursor
			FETCH NEXT FROM pin_cursor
			INTO @pin, @job, @hole, @rig, @long, @lat, @time
            WHILE @@FETCH_STATUS = 0
		    BEGIN  
			IF @pin IS NOT NULL
			   BEGIN TRY
				INSERT INTO wireline_data_pin (job_no, hole_id, rig_id, gps_long, gps_lat, time_start, avg_sp, avg_fc, msg_type, msg, link, pin_type, active) VALUES (@job, @hole, @rig, @long, @lat, @time, null, null, null, null, null,null, 1)
			   END TRY			   
               BEGIN CATCH
				PRINT ''ERROR INSERTING PIN LOCATION for RIG: '' + @rig
			  END CATCH
			FETCH NEXT FROM pin_cursor
			INTO @pin, @job, @hole, @rig, @long, @lat, @time
			END
        CLOSE pin_cursor
		DEALLOCATE pin_cursor
END TRY			   
               BEGIN CATCH
				PRINT ''ERROR INSERTING PIN LOCATION''
			  END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[start_recalc]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author: Damian Puiia
-- Create date: June 23, 2008
-- reloads the start time of the new data pins
-- so that each new file load is what is viewable
-- via the report
-- =============================================
--CREATE OR 
CREATE PROCEDURE [dbo].[start_recalc] AS
-- variable to retain the proper ID''s
     DECLARE @hole nchar(10)
     DECLARE @time datetime
     
BEGIN	
	 begin try 
        DECLARE new_start CURSOR
	    FOR SELECT DISTINCT n.hole, n.start_time 
        FROM dbo.new_start_date n, wireline_data_pin w
        WHERE n.hole = w.hole_id
        AND n.start_time >= w.time_start
        OPEN new_start
	    FETCH NEXT FROM new_start
	    INTO @hole,@time
            WHILE @@FETCH_STATUS = 0
            BEGIN  
	     IF @hole IS NOT NULL
             BEGIN TRY
				UPDATE wireline_data_pin set time_start = @time
                WHERE hole_id = @hole

             END TRY
             BEGIN CATCH
		PRINT ''ERROR INSERTING START TIME for Hole: '' + @hole
	     END CATCH
		
				--execute the speed force calculations for the pin table after the start
				execute avg_sp_fc @hole, @time		


         FETCH NEXT FROM new_start
	     INTO @hole,@time
	     END
        CLOSE new_start
        DEALLOCATE new_start
        END TRY
             BEGIN CATCH
		PRINT ''ERROR recalculating START TIME for Hole: '' + @hole
	     END CATCH
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[start_recalc_new_format]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author: Damian Puiia
-- Create date: June 23, 2008
-- reloads the start time of the new data pins
-- so that each new file load is what is viewable
-- via the report
-- =============================================
--CREATE OR 
CREATE PROCEDURE [dbo].[start_recalc_new_format] AS
-- variable to retain the proper ID''s
     DECLARE @hole nchar(10)
     DECLARE @time datetime
     
BEGIN	
	 begin try 
        DECLARE new_start CURSOR
	    FOR SELECT DISTINCT n.hole, n.start_time 
        FROM dbo.new_start_date_new_format n, wireline_data_pin w
        WHERE n.hole = w.hole_id
        AND n.start_time >= w.time_start
        OPEN new_start
	    FETCH NEXT FROM new_start
	    INTO @hole,@time
            WHILE @@FETCH_STATUS = 0
            BEGIN  
	     IF @hole IS NOT NULL
             BEGIN TRY
				UPDATE wireline_data_pin set time_start = @time
                WHERE hole_id = @hole

             END TRY
             BEGIN CATCH
		PRINT ''ERROR INSERTING START TIME for Hole: '' + @hole
	     END CATCH
		
				--execute the speed force calculations for the pin table after the start
				execute avg_sp_fc @hole, @time		


         FETCH NEXT FROM new_start
	     INTO @hole,@time
	     END
        CLOSE new_start
        DEALLOCATE new_start
        END TRY
             BEGIN CATCH
		PRINT ''ERROR recalculating START TIME for Hole: '' + @hole
	     END CATCH
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[recalc_active_pins_new_format]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author: Martin Poirier
-- Create date: Sept 25, 2008
-- Looks at the end_date of the wireline_load table 
-- for each hole and sets the ''active'' column in the pin table to 0 if the data is older than 5 days
-- =============================================
--CREATE OR 
CREATE PROCEDURE [dbo].[recalc_active_pins_new_format] AS

     DECLARE @hole nchar(10)
     DECLARE @time_end datetime

	BEGIN	
		 BEGIN TRY 
			DECLARE inactive_pins CURSOR
			FOR 
				select n.hole, n.time_end
				FROM dbo.wireline_data_pin pin, dbo.max_end_date_new_format n
				WHERE pin.hole_id = n.hole
				AND DATEDIFF(dd, n.time_end, GETDATE()) >= 10
		
			DECLARE active_pins CURSOR
			FOR
				select n.hole, n.time_end
				FROM dbo.wireline_data_pin pin, dbo.max_end_date_new_format n
				WHERE pin.hole_id = n.hole
				AND DATEDIFF(dd, n.time_end, GETDATE()) <= 10

			OPEN inactive_pins
			FETCH NEXT FROM inactive_pins
			INTO @hole, @time_end
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @hole IS NOT NULL
				BEGIN
					BEGIN TRY
						UPDATE wireline_data_pin set active = 0
						WHERE hole_id = @hole
					END TRY
					BEGIN CATCH
						PRINT ''ERROR UPDATING ACTIVE FLAG FOR HOLE '' + @hole + '' to 0''
					END CATCH
				END

				FETCH NEXT FROM inactive_pins
				INTO @hole, @time_end
			END
			CLOSE inactive_pins
			DEALLOCATE inactive_pins

			OPEN active_pins
			FETCH NEXT FROM active_pins
			INTO @hole, @time_end
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @hole IS NOT NULL
				BEGIN
					BEGIN TRY
						UPDATE wireline_data_pin set active = 1
						WHERE hole_id = @hole
					END TRY
					BEGIN CATCH
						PRINT ''ERROR UPDATING ACTIVE FLAG FOR HOLE '' + @hole + '' to 1''
					END CATCH
				END

				FETCH NEXT FROM active_pins
				INTO @hole, @time_end
			END
			CLOSE active_pins
			DEALLOCATE active_pins


		END TRY
		BEGIN CATCH
			PRINT ''ERROR recalculating ACTIVE FLAG for Hole: '' + @hole
		END CATCH

	END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[recalc_active_pins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author: Martin Poirier
-- Create date: Sept 25, 2008
-- Looks at the end_date of the wireline_load table 
-- for each hole and sets the ''active'' column in the pin table to 0 if the data is older than 5 days
-- =============================================
--CREATE OR 
CREATE PROCEDURE [dbo].[recalc_active_pins] AS

     DECLARE @hole nchar(10)
     DECLARE @time_end datetime

	BEGIN	
		 BEGIN TRY 
			DECLARE inactive_pins CURSOR
			FOR 
				select n.hole, n.time_end
				FROM dbo.wireline_data_pin pin, dbo.max_end_date n
				WHERE pin.hole_id = n.hole
				AND DATEDIFF(dd, n.time_end, GETDATE()) >= 10
		
			DECLARE active_pins CURSOR
			FOR
				select n.hole, n.time_end
				FROM dbo.wireline_data_pin pin, dbo.max_end_date n
				WHERE pin.hole_id = n.hole
				AND DATEDIFF(dd, n.time_end, GETDATE()) <= 10

			OPEN inactive_pins
			FETCH NEXT FROM inactive_pins
			INTO @hole, @time_end
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @hole IS NOT NULL
				BEGIN
					BEGIN TRY
						UPDATE wireline_data_pin set active = 0
						WHERE hole_id = @hole
					END TRY
					BEGIN CATCH
						PRINT ''ERROR UPDATING ACTIVE FLAG FOR HOLE '' + @hole + '' to 0''
					END CATCH
				END

				FETCH NEXT FROM inactive_pins
				INTO @hole, @time_end
			END
			CLOSE inactive_pins
			DEALLOCATE inactive_pins

			OPEN active_pins
			FETCH NEXT FROM active_pins
			INTO @hole, @time_end
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @hole IS NOT NULL
				BEGIN
					BEGIN TRY
						UPDATE wireline_data_pin set active = 1
						WHERE hole_id = @hole
					END TRY
					BEGIN CATCH
						PRINT ''ERROR UPDATING ACTIVE FLAG FOR HOLE '' + @hole + '' to 1''
					END CATCH
				END

				FETCH NEXT FROM active_pins
				INTO @hole, @time_end
			END
			CLOSE active_pins
			DEALLOCATE active_pins


		END TRY
		BEGIN CATCH
			PRINT ''ERROR recalculating ACTIVE FLAG for Hole: '' + @hole
		END CATCH

	END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[post_load_processing]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author: Damian Puiia
-- Create date: June 25, 2008
-- Description:	Stored procedure used to add new 
-- execute all post wireline load processing 
-- =============================================
--CREATE OR 
CREATE PROCEDURE [dbo].[post_load_processing] AS
--execute all post wireline load processing
BEGIN	
    Begin try
    --load new rigs into the wireline_lookup table
    execute new_rigs;
    --load new site locations into the wireline_pins table
    execute new_pins;
    --convert WU/WD to UP/DN for reporting purposes
    execute conv_up_down;
    --calculate new start tiems for the mapping interface
    execute start_recalc;
	--calculate the active/non-active holes
	execute recalc_active_pins;

END TRY
    BEGIN CATCH
		PRINT ''ERROR IN WIRELINE POST PROCESSING''
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[post_load_processing_new_format]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author: Damian Puiia
-- Create date: June 25, 2008
-- Description:	Stored procedure used to add new 
-- execute all post wireline load processing 
-- =============================================
--CREATE OR 
CREATE PROCEDURE [dbo].[post_load_processing_new_format] AS
--execute all post wireline load processing
BEGIN	
    Begin try
    --load new rigs into the wireline_lookup table
    execute new_rigs;
    --load new site locations into the wireline_pins table
    execute new_pins;
    --convert WU/WD to UP/DN for reporting purposes
    execute conv_up_down_new_format;
    --calculate new start tiems for the mapping interface
    execute start_recalc_new_format;
	--calculate the active/non-active holes
	execute recalc_active_pins_new_format;

END TRY
    BEGIN CATCH
		PRINT ''ERROR IN WIRELINE POST PROCESSING''
END CATCH
END
' 
END
