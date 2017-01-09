# AspNetWithVueBinding
<br/>  
就只是一個簡單的範例
<br/>
透過WebAPI與框架撰寫的CRUD範例
<br/>  
Video: https://www.youtube.com/embed/Q-Kbdu48Unw
<br/> 
![alt tag](http://arock.blob.core.windows.net/blogdata201701/05-190155-e4bf9e18-5b4c-447d-802a-8e0021ceab26.png)
<br/>  
這是一個使用純HTML+WebAPI做的SPA CRUD範例。你會看到，新增和修改是在同一個頁面(AddNewOrUpdate.html)完成的，而資料列表與刪除則是在index.html)，所有的資料處理都拉到BO內開發，WebAPI單純就被視為服務層，底下連結是Source與參考資料，過幾天我再抽空整理這個範例的完整說明。
<br/> 
<br/> 
請留意:為了保持單純，這個CRUD的資料庫是用記憶體物件模擬，而非連實體資料庫(以避免相依資料庫)，但由於查詢都是很簡單的LINQ，因此不妨礙整個Demo。
<br/>
<br/>此範例採用的SPA架構說明 :
<br/>http://studyhost.blogspot.tw/2016/12/aspnet-web-2-spa.html
