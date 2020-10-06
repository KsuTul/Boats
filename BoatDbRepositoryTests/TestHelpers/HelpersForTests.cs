namespace BoatStorage.Services.Tests
{
    using System;
    using Boatstorage.Data;
    using Boatstorage.Data.DAO;

    public static class HelpersForTests
    {
        private static string ExceptionMessage = "This is not a correct type";
        private static string ExMessage = "This is unexisisted key";

        public static object GetSpecParameter( Boat boat, string key, string type)
        {
            switch (type)
            {
                case nameof(Int32):
                   return boat.GetSpecParameter<int>(key);

                case nameof(Nullable<int>):
                   return boat.GetSpecParameter<int?>(key);

                case nameof(String):
                   return boat.GetSpecParameter<string>(key);
            }

            return null;
        }

        public static object GetValue(string type, string value)
        {
            Type t = typeof(int?);
            t = Nullable.GetUnderlyingType(t) ?? t;

            switch (type)
            {
                case nameof(Int32):
                    return (int)Convert.ChangeType(value, typeof(int));

                case nameof(Nullable<int>):

                    return (int?)Convert.ChangeType(value, t);

                case nameof(String):
                    return (string)Convert.ChangeType(value, typeof(string));
            }

            throw new Exception(HelpersForTests.ExceptionMessage);
        }

        public static Type GetType(string type)
        {
            switch (type)
            {
                case nameof(Catamaran):
                    return typeof(Catamaran);

                case nameof(Canoe):
                    return typeof(Canoe);

                case nameof(HuntingBoat):
                    return typeof(HuntingBoat);

                case nameof(Motorboat):
                    return typeof(Motorboat);

                case nameof(InflatableBoat):
                    return typeof(InflatableBoat);
            }

            return null;
        }
    }

}
