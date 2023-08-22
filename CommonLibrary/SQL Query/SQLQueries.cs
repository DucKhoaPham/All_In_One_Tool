using CommonLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.SQL_Query
{
    class SQLQueries
    {
        List<SQLQuery> queries = new List<SQLQuery>
            {
                new SQLQuery
                {
                    QueryText = "SELECT * FROM Table2 WHERE ColumnName = @Value",
                    Parameters = new Dictionary<string, object>
                    {
                        { "@Value", "SomeValue" }
                    }
                },
                new SQLQuery
                {
                    QueryText = @"SELECT  text,total_elapsed_time,*
                    FROM sys.dm_exec_requests  
                    CROSS APPLY sys.dm_exec_sql_text(sql_handle)",
                    Info = SQLQuery.NameQuery.CHECK_QUERIES
                },
                new SQLQuery
                {
                    QueryText = @"select cmd,* from sys.sysprocesses
                    where blocked > 0",
                    Info = SQLQuery.NameQuery.CHECK_DEADLOCK
                },
                new SQLQuery
                {
                    QueryText = @"select P.spid, right(convert(varchar, 
                            dateadd(ms, datediff(ms, P.last_batch, getdate()), '1900-01-01'), 
                            121), 12) as 'batch_duration'
                            , P.program_name, P.hostname, P.loginame, p.status
                            from master.dbo.sysprocesses P
                            where P.spid > 50
                            and      P.status not in ('background', 'sleeping')
                            and      P.cmd not in ('AWAITING COMMAND'
                                                ,'MIRROR HANDLER'
                                                ,'LAZY WRITER'
                                                ,'CHECKPOINT SLEEP'
                                                ,'RA MANAGER')
                            order by batch_duration desc",
                    Info = SQLQuery.NameQuery.CHECK_PROGRAMS
                },
                 new SQLQuery
                {
                    QueryText = @"SELECT t.NAME AS TableName,
                           s.Name AS SchemaName,
                           p.rows AS RowCounts,
                           SUM(a.total_pages) * 8 AS TotalSpaceKB,
                           SUM(a.used_pages) * 8 AS UsedSpaceKB,
                           (SUM(a.total_pages) - SUM(a.used_pages)) * 8 AS UnusedSpaceKB
                    FROM sys.tables t
                    INNER JOIN sys.indexes i ON t.OBJECT_ID = i.object_id
                    INNER JOIN sys.partitions p ON i.object_id = p.OBJECT_ID
                    AND i.index_id = p.index_id
                    INNER JOIN sys.allocation_units a ON p.partition_id = a.container_id
                    LEFT OUTER JOIN sys.schemas s ON t.schema_id = s.schema_id
                    WHERE t.NAME NOT LIKE 'dt%'
                      AND t.is_ms_shipped = 0
                      AND i.OBJECT_ID > 255
                    GROUP BY t.Name,
                             s.Name,
                             p.Rows
                    ORDER BY t.Name",
                    Info = SQLQuery.NameQuery.CHECK_INFO
                },
            };
    }
}
