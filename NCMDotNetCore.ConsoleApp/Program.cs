﻿using NCMDotNetCore.ConsoleApp.AdoDotNetExamples;
using NCMDotNetCore.ConsoleApp.EFCoreExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");


//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "DESKTOP-K673C05";
//stringBuilder.InitialCatalog = "NCMDotNetCore";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sa@123";
//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
//connection.Open();
//Console.WriteLine("Connection Open");

//string query = "select * from tbl_blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);

//connection.Close();
//Console.WriteLine("Connection Close");

////dataset => datatable
////datatable => datarow
////datarow => datacolumn

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog Id =>" + dr["BlogId"]);
//    Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
//    Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
//    Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
//    Console.WriteLine("------------------------------------");
//}
////Ado.Net Read

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
adoDotNetExample.Create("title", "author", "content");
////adoDotNetExample.Update(4,"New title ", "New author", "New content");
////adoDotNetExample.Delete(5);
////adoDotNetExample.Edit(1);

//EFCoreExample efCoreExample = new EFCoreExample();
//efCoreExample.Run();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//Console.WriteLine("EFcore finished");
//Console.ReadKey();