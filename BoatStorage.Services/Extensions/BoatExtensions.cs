namespace BoatStorage.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Boatstorage.Data;
    using Boatstorage.Data.DAO;
    using Boatstorage.Data.Mapping;

    public static class BoatExtensions
    {
        public static string ErrorMessage = "This BoatType doesn't exist in current context";

        public static T GetSpecParameter<T>(this Boat dbModel, string key)
        {
            Type t = typeof(T);
            t = Nullable.GetUnderlyingType(t) ?? t;

            string pValue = dbModel.BoatsSpecificParameters
                .FirstOrDefault(s => s.Key == key)?.Value;
            return pValue != null ? (T)Convert.ChangeType(pValue, t) : default(T);
        }

        public static void MapToBaseDomainBoat<T>(this Boat dbModel, T domainModel)
       where T : FloatingCrafts
        {
            domainModel.Id = dbModel.Id;
            domainModel.Manufacturer = dbModel.Manufacturer;
            domainModel.Displacement = dbModel.Displacement;
            domainModel.Name = dbModel.Name;
            domainModel.Speed = dbModel.Speed;
            domainModel.NumberOfSeats = dbModel.NumberOfSeats;
        }

        public static Engine GetEngineParameters(this Boat dbModel)
        {
            return dbModel.GetSpecParameter<int?>(nameof(Engine) + "." + nameof(Engine.Power))
                == null ? null : new Engine()
                {
                    Power = dbModel.GetSpecParameter<int?>(nameof(Engine) + "." + nameof(Engine.Power)).Value,
                    Manufacturer = dbModel.GetSpecParameter<string>(nameof(Engine) + "." + nameof(Engine.Manufacturer)),
                };
        }

        public static FloatingCrafts MapToDomainBoat(this Boat dbModel)
        {
            FloatingCrafts retVal = null;
            if (dbModel.BoatType == typeof(Catamaran).Name)
            {
                retVal = new Catamaran();
                dbModel.MapToBaseDomainBoat(retVal);
            }
            else if (dbModel.BoatType == typeof(Canoe).Name)
            {
                retVal = new Canoe();
                dbModel.MapToBaseDomainBoat(retVal);
                ((Canoe)retVal).NumberOfPaddles = dbModel.GetSpecParameter<int>(nameof(Canoe.NumberOfPaddles));
            }
            else if (dbModel.BoatType == typeof(HuntingBoat).Name)
            {
                retVal = new HuntingBoat();
                dbModel.MapToBaseDomainBoat(retVal);
                ((HuntingBoat)retVal).NumberOfPaddles = dbModel.GetSpecParameter<int>(nameof(HuntingBoat.NumberOfPaddles));
            }
            else if (dbModel.BoatType == typeof(Motorboat).Name)
            {
                retVal = new Motorboat();
                dbModel.MapToBaseDomainBoat(retVal);
                ((Motorboat)retVal).Engine = dbModel.GetEngineParameters();
            }
            else if (dbModel.BoatType == typeof(InflatableBoat).Name)
            {
                retVal = new InflatableBoat();
                dbModel.MapToBaseDomainBoat(retVal);
                ((InflatableBoat)retVal).Engine = dbModel.GetEngineParameters();
            }
            else
            {
                throw new ArgumentException(BoatExtensions.ErrorMessage);
            }

            return retVal;
        }

        /// <summary>
        /// Map base properties of DAO models from Domain models.
        /// </summary>
        public static void MapToBaseDAOBoat<T>(this Boat dbModel, T domainModel)
            where T : IBoat
        {
            dbModel.Manufacturer = domainModel.Manufacturer;
            dbModel.Displacement = domainModel.Displacement;
            dbModel.Name = domainModel.Name;
            dbModel.Speed = domainModel.Speed;
            dbModel.NumberOfSeats = domainModel.NumberOfSeats;

            if (domainModel is Catamaran)
            {
                dbModel.BoatType = typeof(Catamaran).Name;
            }

            if (domainModel is Canoe)
            {
                dbModel.BoatType = typeof(Canoe).Name;
            }

            if (domainModel is HuntingBoat)
            {
                dbModel.BoatType = typeof(HuntingBoat).Name;
            }

            if (domainModel is Motorboat)
            {
                dbModel.BoatType = typeof(Motorboat).Name;
            }

            if (domainModel is InflatableBoat)
            {
                dbModel.BoatType = typeof(InflatableBoat).Name;
            }
        }

        public static void MapSpecParam(this Boat daoModel, string key, string value)
        {
            var specParam = daoModel.BoatsSpecificParameters.FirstOrDefault(x => x.Key == key);

            if (specParam == null)
            {
                specParam = new BoatSpecificParameters() { Key = key };
                daoModel.BoatsSpecificParameters.Add(specParam);
            }

            specParam.Value = value;
        }

        /// <summary>
        /// Map to DAO models and add elements to BoatSpecificParameters depending on the type of boat.
        /// </summary>
        public static Boat MapToDaoModels(this Boat daoBoat, IBoat domainModel)
        {
            daoBoat.MapToBaseDAOBoat(domainModel);

            if (domainModel is Canoe)
            {
                if (((Canoe)domainModel).NumberOfPaddles > 0)
                {
                    daoBoat.MapSpecParam(nameof(Canoe.NumberOfPaddles), ((Canoe)domainModel).NumberOfPaddles.ToString());
                }
            }

            if (domainModel is HuntingBoat)
            {
                if (((HuntingBoat)domainModel).NumberOfPaddles > 0)
                {
                    daoBoat.MapSpecParam(nameof(HuntingBoat.NumberOfPaddles), ((HuntingBoat)domainModel).NumberOfPaddles.ToString());
                }
            }

            if (domainModel is Motorboat)
            {
                if (((Motorboat)domainModel).Engine != null)
                {
                    daoBoat.MapSpecParam(nameof(Engine) + nameof(Engine.Power), ((Motorboat)domainModel).Engine.Power.ToString());
                    daoBoat.MapSpecParam(nameof(Engine) + nameof(Engine.Manufacturer), ((Motorboat)domainModel).Engine.Manufacturer);
                }
            }

            if (domainModel is InflatableBoat)
            {
                if (((InflatableBoat)domainModel).NumberOfPaddles > 0)
                {
                    daoBoat.MapSpecParam(nameof(InflatableBoat.NumberOfPaddles), ((InflatableBoat)domainModel).NumberOfPaddles.ToString());
                }

                if (((InflatableBoat)domainModel).Engine != null)
                {
                    daoBoat.MapSpecParam(nameof(Engine) + nameof(Engine.Power), ((InflatableBoat)domainModel).Engine.Power.ToString());
                    daoBoat.MapSpecParam(nameof(Engine) + nameof(Engine.Manufacturer), ((InflatableBoat)domainModel).Engine.Manufacturer);
                }
            }

            return daoBoat;
        }
    }
}
