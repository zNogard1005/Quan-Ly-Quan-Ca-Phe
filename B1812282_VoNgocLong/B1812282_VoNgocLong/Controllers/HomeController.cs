using B1812282_VoNgocLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B1812282_VoNgocLong.Controllers
{
    public class HomeController : Controller
    {
        DBIO db = new DBIO();
        public ActionResult Index()
        {
            List<BENHNHAN> list = db.getList_BENHNHAN();
            return View(list);
        }

        //Không dùng tham số gì cả cho Create()
        public ActionResult Create()
        {
            return View();
        }
        //Khi gọi đến phương thức addObject_BENHNHAN(BENHNHAN s) in DBIO.cs
        //thì đồng thời ta cần một thông điệp nào đó để nó load dữ liệu lên
        //=> dùng [HttpPost]
        [HttpPost]
        public ActionResult Create(BENHNHAN s)
        {
            db.addObject_BENHNHAN(s);
            //sau khi thêm rồi, ta điều hướng người dùng đến trang Index
            return RedirectToAction("Index");
        }
        //Sửa sách phức tạp hơn thêm (create) vì ta cần biết sửa sách nào?
        //Ta cần biết id của quyển sách bạn đang định sửa
        public ActionResult Edit(string id)
        {
            BENHNHAN s = db.getObject_BENHNHAN(id);
            return View(s); //lấy ra quyển sách thì sau đó mới sửa được
        }
        [HttpPost] //Ý nghĩa là khi bạn gọi Edit nó cần gửi lên thông điệp để sửa thông tin này
        public ActionResult Edit(BENHNHAN s) //phải đặt tên là Edit như hàm bên trên, không dùng tên khác
        {
            db.editObject_BENHNHAN(s);
            return RedirectToAction("Index"); //Khi sửa rồi thì hệ thống sẽ điều hướng quay về trang chủ
        }
        //Xóa một quyển sách
        //Ta cần biết id của quyển sách bạn đang định xóa
        public ActionResult Delete(string id)
        {
            BENHNHAN s = db.getObject_BENHNHAN(id);
            return View(s); //lấy ra quyển sách thì sau đó mới xóa được
        }
        [HttpPost] //Ý nghĩa là khi bạn gọi Delete nó cần gửi lên thông điệp để xóa thông tin này
        public ActionResult Delete(BENHNHAN s)
        {
            db.deleteObject_BENHNHAN(s);
            return RedirectToAction("Index"); //Khi xóa rồi thì hệ thống sẽ điều hướng quay về trang chủ
        }
        //Xem một quyển sách
        //Ta cần biết id của quyển sách bạn đang định xem chi tiết
        public ActionResult Details(string id)
        {
            BENHNHAN s = db.getObject_BENHNHAN(id);
            return View(s); //lấy ra quyển sách cần xem
        }

    }
}