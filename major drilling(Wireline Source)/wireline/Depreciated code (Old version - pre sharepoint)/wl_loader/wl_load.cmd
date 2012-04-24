@echo off
REM /***************************************************************/
REM /* Created By  : Damian Puiia                                  */
REM /* Created On  : April 14 2008                                 */
REM /* Description : used for the loading of wireline data         */
REM /***************************************************************/
REM /***************************************************************/

If exist C:\wireline_repository\load\dirlist.txt GOTO SKIP

if exist C:\wireline_repository\load\wl_upload.log MOVE C:\wireline_repository\load\wl_upload.log "C:\wireline_repository\load\archive_log\wl_upload.log"
if exist C:\wireline_repository\load\wl_archive.log MOVE C:\wireline_repository\load\wl_archive.log "C:\wireline_repository\load\archive_log\wl_archive.log"


Dir C:\wireline_repository\load\dumpzone\ /b >> dirlist.txt


FOR /f %%G IN (C:\wireline_repository\load\dirlist.txt) do for /f "tokens=1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25* delims=," %%a in (C:\wireline_repository\load\dumpzone\%%G) do sqlcmd -W -l5 -h-1 -S 10.0.32.87 -U sa -P password -Q"insert into DamianTest.dbo.test_load values ('%%a', '%%b', '%%c', '%%d', '%%e', %%f, %%g, '%%h','%%i', '%%j', '%%k', '%%l', '%%m', '%%n', '%%o', %%p, CAST('%%r'+' '+'%%q' AS datetime), CAST('%%r' AS datetime), %%s, %%t, %%u, %%v, CAST('%%r'+' '+'%%w' AS datetime), %%x, %%y)"  >> C:\wireline_repository\load\wl_upload.log

FOR /f %%G IN (C:\wireline_repository\load\dirlist.txt) do MOVE C:\wireline_repository\load\dumpzone\%%G "C:\wireline_repository\load\archive\%%G" >> C:\wireline_repository\load\wl_archive.log

If exist C:\wireline_repository\load\dirlist.txt DEL C:\wireline_repository\load\dirlist.txt


:SKIP