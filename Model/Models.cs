using System;
namespace Task18_BootcampRefactory.Model
{
    public enum Gender
    {
        male,
        female
    }

    public class Customers
    {
        public int Id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string password { get; set; }
        public Gender sex { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;
    }

    public class Customers_Payment_Card
    {
        public int Id { get; set; }
        public int customer_id { get; set; }
        public string name_on_card { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public int postal_code { get; set; }
        public string credit_card_number { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;

        public Customers customer { get; set; }
    }

    public class Merchant
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;
    }

    public class Products
    {
        public int Id { get; set; }
        public int merchant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;

        public Merchant merchant { get; set; }
    }

    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class RequestData<T>
    {
        public Data<T> data { get; set; }
    }

    public class Data<T>
    {
        public T attributes { get; set; }
    }
}
