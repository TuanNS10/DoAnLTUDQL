Đồ Án Quản Lý Bán Hàng

Các bước cài đặt:
1.	Chạy script “QLBH.sql” trong file bài nộp Import cơ sở dữ liệu vào SQL Server (version 2014).
2.	Cấu hình lại ConnectionStrings trong file “App.config” mục “data source” cho đồng bộ với connection trong máy chủ SQL Server hiện tại trong tab:

<connectionStrings>
<add name="QLBHEntities" connectionString="metadata=res://*/Model.csdl|res://*/Model.ssdl|res://*/Model.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-FDU9ISA\SQLEXPRESS;initial catalog=QLBH;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
3.	Build và chạy chương trình.
4.	Đăng nhập với tài khoản: admin và mật khẩu: admin

Mô tả đồ án:

Milestone 1.
Các module chính đã hoàn thành: Category và Product - Loại sản phẩm, Sản phẩm.
•	Thêm một loại sản phẩm, thêm một sản phẩm.

•	Cập nhật thông tin của một loại sản phẩm, cập nhật thông tin của một sản phẩm.

•	Xóa một loại sản phẩm (không cho xóa nếu còn con), xóa một sản phẩm.

•	Hiển thị danh sách sản phẩm theo loại sản phẩm có phân trang.






Milestone 2.

Các module chính đã hoàn thành: Transaction data – Đơn hàng.
•	Chọn sản phẩm và tạo các đơn hàng.

•	Hiển thị danh sách đơn hàng có phân trang

•	Cập nhật trạng thái đơn hàng : Mới tạo, Hoàn tất, Đã hủy.

•	Xóa một đơn hàng


Milestone 3.

Các module chính đã hoàn thành: Chart – Biểu đồ thống kê.
•	Biểu đồ cột : thống kê số lượng sản phẩm đã bán.

•	Biểu đồ đường : trong khoảng từ tháng đến tháng thống kê doanh thu.




