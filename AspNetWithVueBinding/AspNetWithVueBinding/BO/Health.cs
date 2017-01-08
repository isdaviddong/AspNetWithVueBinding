using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using isRock.Framework.WebAPI;

namespace AspNetWithVueBinding.BO
{
    /// <summary>
    /// 一筆學生資料
    /// </summary>
    public class StudentInfo
    {
        public Guid guid { get; set; }
        public string StudentName { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float BMIValue { get; set; }
        public string Memo { get; set; }
    }


    /// <summary>
    /// 給前端呼叫的API
    /// </summary>
    public class Health
    {
        #region"因為是範例，我們用靜態物件代替資料庫"
        private static List<StudentInfo> _StudentInfomation = null;
        /// <summary>
        /// 因為是範例，因此用這個屬性替代資料庫
        /// </summary>
        public List<StudentInfo> StudentInfomation
        {
            get
            {
                if (_StudentInfomation == null || _StudentInfomation.Count <= 0)
                {
                    //準備假資料
                    _StudentInfomation = new List<StudentInfo>();
                    _StudentInfomation.Add(new StudentInfo { StudentName = "王曉明", Height = 170, Weight = 72, guid = Guid.NewGuid() });
                    _StudentInfomation.Add(new StudentInfo { StudentName = "張曉春", Height = 180, Weight = 75, guid = Guid.NewGuid() });
                    _StudentInfomation.Add(new StudentInfo { StudentName = "田豐盛", Height = 175, Weight = 60, guid = Guid.NewGuid() });
                    _StudentInfomation.Add(new StudentInfo { StudentName = "楊明山", Height = 165, Weight = 90, guid = Guid.NewGuid() });
                    _StudentInfomation.Add(new StudentInfo { StudentName = "令狐衝", Height = 172, Weight = 80, guid = Guid.NewGuid() });
                }
                //計算BMI
                foreach (var item in _StudentInfomation)
                {
                    var height = item.Height / 100;
                    item.BMIValue = item.Weight / (height * height);
                    if (item.BMIValue > 30)
                        item.Memo = "過重!";
                    if (item.BMIValue < 20)
                        item.Memo = "太瘦!";
                }
                return _StudentInfomation;
            }
        }
        #endregion

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public ExecuteCommandDefaultResult<List<StudentInfo>> GetData()
        {
            //取得記憶體(因為是範例，我們用記憶體模擬資料庫)中完整資料，並回傳
            return new ExecuteCommandDefaultResult<List<StudentInfo>>()
            {
                isSuccess = true,
                Data = StudentInfomation //將記憶體(模擬資料庫)中的資料回傳
            };
        }


        /// <summary>
        /// 刪除一筆資料
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ExecuteCommandDefaultResult<List<StudentInfo>> Remove(Guid guid)
        {
            //找到資料
            var ret = from c in StudentInfomation
                      where c.guid == guid
                      select c;
            //如果有
            if (ret.Count() > 0)
            {
                //移除
                StudentInfomation.Remove(ret.FirstOrDefault());
            }

            return GetData();
        }

        /// <summary>
        /// 新增或更新一筆資料
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ExecuteCommandDefaultResult<List<StudentInfo>> AddNewOrUpdate(StudentInfo StudentInfo)
        {
            //判斷guid決定新增或更新
            if (StudentInfo.guid == null || StudentInfo.guid == Guid.Empty)
            {
                //新增
                StudentInfo.guid = Guid.NewGuid();
                StudentInfomation.Add(StudentInfo);
            }
            else
            {
                //找到特定編號那筆資料
                var ret = from c in StudentInfomation
                          where c.guid == StudentInfo.guid
                          select c;
                //更新
                if (ret.Count() > 0)
                {
                    ret.FirstOrDefault().StudentName = StudentInfo.StudentName;
                    ret.FirstOrDefault().Height = StudentInfo.Height;
                    ret.FirstOrDefault().Weight = StudentInfo.Weight;
                }
            }
            //回傳所有資料(其實前端沒用到)
            return GetData();
        }

        /// <summary>
        /// 依照guid取得一筆特定資料
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ExecuteCommandDefaultResult<StudentInfo> LoadData(Guid guid)
        {
            //找到特定編號那筆資料
            var ret = from c in StudentInfomation
                      where c.guid == guid
                      select c;

            if (ret.Count() <= 0)
                throw new Exception($"指定的資料{guid}不存在");
            //回傳該筆資料
            return new ExecuteCommandDefaultResult<StudentInfo>()
            {
                isSuccess = true,
                Data = ret.FirstOrDefault()
            };
        }
    }
}