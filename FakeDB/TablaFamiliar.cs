        }


        public static void InstanciarFamiliar(int numeroFamiliar)
        {
            for (int i = 0; i < numeroFamiliar; i++)
            {
                familiares.Add(new AtributosFamiliar(i));
            }
        }

        public static String ToJSON()
        {
            if (familiares.Count == 0)
            {
                InstanciarFamiliar(10);
            }
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(familiares, options);
        }


     }
}
