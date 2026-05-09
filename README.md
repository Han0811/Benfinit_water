# Benfinit_water

**Hệ thống quản lý cơ sở dữ liệu thủy lợi tỉnh Nam Định**

Desktop application xây dựng bằng WPF (.NET 8.0) để quản lý, tra cứu và hiển thị bản đồ các công trình thủy lợi trên địa bàn tỉnh Nam Định.

## Tính năng

- **Quản lý đơn vị hành chính** — cây phân cấp tỉnh/huyện/xã/phường/thị trấn, chuyển đơn vị
- **Quản lý quy hoạch** — các kỳ quy hoạch thủy lợi, kèm file bản đồ PDF
- **Quản lý công trình thủy lợi** — thông tin chi tiết từng công trình
- **Quản lý đập tràn** — chiều cao, chiều dài, vật liệu, tình trạng
- **Quản lý trạm bơm** — công suất (kW), số máy bơm, vị trí
- **Quản lý đường ống** — chiều dài, đường kính, vật liệu
- **Diện tích tưới** — theo đơn vị hành chính, mùa vụ, năm
- **Bản đồ tương tác** — hiển thị công trình trên GMap.NET (OpenStreetMap)
- **Tìm kiếm toàn hệ thống** — tìm kiếm không dấu, gợi ý tự động
- **Phân quyền người dùng** — admin/superuser/người dùng thường
- **Báo cáo thống kê** — tài khoản, lượt truy cập
- **Lịch sử truy cập** — audit log chi tiết
- **Giao diện Material Design** — WPF với MaterialDesignThemes

## Công nghệ

| Thành phần | Công nghệ |
|-----------|-----------|
| Ngôn ngữ | C# |
| Framework | .NET 8.0 (Windows, WPF) |
| Giao diện | WPF + MaterialDesignThemes (neumorphism) |
| Bản đồ | GMap.NET WPF |
| Cơ sở dữ liệu | MySQL 8.0 |
| Kết nối DB | MySql.Data |

## Kiến trúc

```
Benfinit_water/
├── Model/          # Truy vấn CSDL (CRUD + stored procedures)
├── Controller/     # Logic nghiệp vụ
├── View/           # Giao diện WPF (XAML UserControls + Windows)
│   ├── ctrl_*.xaml       # UserControls cho từng màn hình
│   ├── win_*.xaml        # Cửa sổ dialog
│   └── MapControlUserControl  # Bản đồ
├── Assets/         # Hình ảnh nút bấm (neumorphic)
├── App.config      # Chuỗi kết nối MySQL
├── backup9.sql     # Backup cơ sở dữ liệu
└── Benfinit_water.sln    # Visual Studio Solution
```

## Cơ sở dữ liệu

**Database:** `benfinit_water` (MySQL, local)

Các bảng chính:
- `users` — tài khoản người dùng
- `co_so` — đơn vị hành chính (cây phân cấp)
- `muc_do_hanh_chinh` — cấp hành chính (tỉnh/huyện/xã...)
- `quyhoach` — kỳ quy hoạch
- `congtrinhthuyloi` — công trình thủy lợi
- `daptran` — đập tràn
- `trambom` — trạm bơm
- `duongong` — đường ống
- `dientichtuoi` — diện tích tưới
- `access_history` — lịch sử truy cập

## Cài đặt & Chạy

1. **Cài đặt .NET 8.0 SDK** — https://dotnet.microsoft.com/en-us/download/dotnet/8.0
2. **Cài đặt MySQL 8.0** và khôi phục database từ `backup9.sql`
3. **Cập nhật chuỗi kết nối** trong `App.config` nếu cần:
   ```xml
   Server=localhost;Database=benfinit_water;Uid=root;Pwd=123456;
   ```
4. Mở `Benfinit_water.sln` bằng Visual Studio 2022
5. Build & Run (F5)