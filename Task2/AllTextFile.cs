using System.Collections.Generic;

namespace Task2
{
    class AllTextFile
    {
        static public List<string> list_io = new List<string>(); // хранит номера которые необходимо сохранить
        static public bool io;
        static public List<string> lineS { get; set; } // хранение всех строк
        static public List<string> temp_list { get; set; } = new List<string>(); //хранение отрывка файла
        static public List<string> temp_list_file { get; set; } = new List<string>(); //хранение отрывка файла
        static public List<string> code { get; set; } = new List<string>() { "<cad_number>", "<reg_numb_border>", "<sk_id>", "</cad_number>", "</reg_numb_border>", "</sk_id>" }; // содержит все теги обозначающие id
        static public Dictionary<string, string> type_object { get; set; } = new Dictionary<string, string>() //содержит имена категорий - ключи и их теги - значения
            {
                { "land record", "<land_record>" },
                { "build record", "<build_record>" },
                { "construction record", "<construction_record>" },
                { "spatial data", "<spatial_data>" },
                { "municipal boundaries", "<municipal_boundaries>" },
                { "zones and territories record", "<zones_and_territories_record>" }
            };
        static public List<string> s_end { get; set; } = new List<string>() //окончания отрывков
            {
                "</land_record>",
                "</build_record>",
                "</construction_record>",
                "</spatial_data>",
                "</municipal_boundaries>",
                "</zones_and_territories_record>"
            };
        static public List<string> s { get; set; } = new List<string>(type_object.Keys); // названия категорий

        static public List<BaseItem> item0 = new List<BaseItem>();

        static public Dictionary<string, string> go_back = new Dictionary<string, string>(); // по номеру найти отрезок, содержит номера - ключи и число 
    }
}
