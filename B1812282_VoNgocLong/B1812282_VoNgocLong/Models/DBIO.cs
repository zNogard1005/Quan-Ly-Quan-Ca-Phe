using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B1812282_VoNgocLong.Models
{
    public class DBIO
    {
        B1812282_VoNgocLongEntities mydb = new B1812282_VoNgocLongEntities();
        //hàm getList_BENHNHAN() để thực hiện một câu truy vấn
        //trả về một danh sách dùng iQuery
        public List<BENHNHAN> getList_BENHNHAN()
        {
            //access to the BENHNHAN table to read all rows
            return mydb.BENHNHANs.ToList();
        }

        //hàm getObject_BENHNHAN(string id) trả về một quyển sách theo id
        public BENHNHAN getObject_BENHNHAN(string id)
        {
            //biểu thức so sánh có cú pháp như C#
            //chứ không phải của SQL
            return mydb.BENHNHANs.Where(c => c.MABN == id).FirstOrDefault();
        }
        //hàm addObject_BENHNHAN(BENHNHAN s) thêm vào một quyển sách
        public void addObject_BENHNHAN(BENHNHAN s)
        {
            mydb.BENHNHANs.Add(s);
            mydb.SaveChanges();
        }
        //hàm editObject_BENHNHAN(BENHNHAN s) sửa một quyển sách
        public void editObject_BENHNHAN(BENHNHAN s)
        {
            BENHNHAN x = getObject_BENHNHAN(s.MABN);
            x.TENBN = s.TENBN;
            x.NGAYSINH = s.NGAYSINH;
            x.GIOITINH = s.GIOITINH;
            x.DOITUONG = s.DOITUONG;
            x.DIENTHOAI = s.DIENTHOAI;
            x.DIACHI = s.DIACHI;
            mydb.SaveChanges();
        }
        //hàm deleteObject_BENHNHAN(BENHNHAN s) xóa một quyển sách s
        public void deleteObject_BENHNHAN(BENHNHAN s)
        {
            BENHNHAN x = getObject_BENHNHAN(s.MABN);
            mydb.BENHNHANs.Remove(x);
            mydb.SaveChanges();
        }
    }
}