using System;
using System.Data;
using DAL;
namespace BL
{

    public class clsCategory
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }


        public clsCategory()
        {
            this.CategoryID = default;
            this.CategoryName = default;


            Mode = enMode.AddNew;

        }

        private clsCategory(int CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;


            Mode = enMode.Update;

        }

        private bool _AddNewCategory()
        {
            //call DataAccess Layer 

            this.CategoryID = DAL_Categories.AddNewCategory(this.CategoryName);

            return (this.CategoryID != -1);

        }

        private bool _UpdateCategory()
        {
            //call DataAccess Layer 

            return DAL_Categories.UpdateCategory(this.CategoryID, this.CategoryName);

        }

        public static clsCategory Find(int CategoryID)
        {
            string CategoryName = default;


            if (DAL_Categories.GetCategoryInfoByID(CategoryID, ref CategoryName))
                return new clsCategory(CategoryID, CategoryName);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCategory())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCategory();

            }




            return false;
        }

        public static DataTable GetAllCategories() { return DAL_Categories.GetAllCategories(); }

        public static bool DeleteCategory(int CategoryID) { return DAL_Categories.DeleteCategory(CategoryID); }

        public static bool isCategoryExist(int CategoryID) { return DAL_Categories.IsCategoryExist(CategoryID); }


    }

}