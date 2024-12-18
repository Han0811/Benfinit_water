using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Benfinit_water.Controller;
using Benfinit_water.Model;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for win_CapNhatCoSo.xaml
    /// </summary>
    public partial class win_CapNhatCoSo : Window
    {
        public List<_CoSoModel> CoSo = _CoSoProvider.getCoSo();
        public _CoSoModel myCoSo;
        public int _id;
        public int idnontaget;
        private List<usermodel> users= _userprovider.GetUsers();
        private usermodel myuser;
        
        

        public win_CapNhatCoSo(int __id, int _idnontaget)
        {
            InitializeComponent();
            idnontaget = _idnontaget;
            _id = __id;
            myCoSo = _CoSoProvider.FindCoSoFirstById(CoSo, _id);
            myuser = _thong_tin_user.GetUserById(idnontaget, users);
            // Gán giá trị cho các TextBox từ đối tượng myCoSo
            idtbx.Text = _id.ToString();
            nametbx.Text = myCoSo.name;
            muc_do_hanh_chinh_idtbx.Text = myCoSo.muc_do_hanh_chinh_id.ToString();
            truc_thuoctbx.Text = myCoSo.truc_thuoc.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!myuser.IsAdmin)
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa");
                CoSo = _CoSoProvider.getCoSo();
                myCoSo = _CoSoProvider.FindCoSoFirstById(CoSo, _id);
                idtbx.Text = _id.ToString();
                nametbx.Text = myCoSo.name;
                muc_do_hanh_chinh_idtbx.Text = myCoSo.muc_do_hanh_chinh_id.ToString();
                truc_thuoctbx.Text = myCoSo.truc_thuoc.ToString();
                return;
            }
            string tempname = null;
            int? tempmuc_do_hanh_chinh_id = null; // Nullable int
            int? temptruc_thuoc = null; // Nullable int

            // Kiểm tra và gán giá trị mới nếu có sự thay đổi
            if (nametbx.Text != myCoSo.name)
                tempname = nametbx.Text;

            if (muc_do_hanh_chinh_idtbx.Text != myCoSo.muc_do_hanh_chinh_id.ToString())
            {
                // Chuyển đổi thành int nếu có giá trị
                if (int.TryParse(muc_do_hanh_chinh_idtbx.Text, out int result))
                    tempmuc_do_hanh_chinh_id = result;
            }

            if (truc_thuoctbx.Text != myCoSo.truc_thuoc.ToString())
            {
                // Chuyển đổi thành int nếu có giá trị
                if (int.TryParse(truc_thuoc.Text, out int result))
                    temptruc_thuoc = result;
            }

            // Gọi phương thức f_coso để cập nhật
            if(_CoSoProvider.f_coso(0, idnontaget, _id, tempname, tempmuc_do_hanh_chinh_id, temptruc_thuoc)) MessageBox.Show("Cập nhật thành công");
            CoSo = _CoSoProvider.getCoSo();
            myCoSo = _CoSoProvider.FindCoSoFirstById(CoSo, _id);
            idtbx.Text = _id.ToString();
            nametbx.Text = myCoSo.name;
            muc_do_hanh_chinh_idtbx.Text = myCoSo.muc_do_hanh_chinh_id.ToString();
            truc_thuoctbx.Text = myCoSo.truc_thuoc.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn xóa cơ sở này?",
                                     "Xác nhận",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Nếu người dùng chọn Yes
                if (_CoSoProvider.f_coso(-1, idnontaget, _id, null, null, null)) MessageBox.Show("Xóa cơ sở thành công");
                
            }
            else
            {
                // Nếu người dùng chọn No
                MessageBox.Show("Đã hủy thao tác cập nhật.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
    }
}
