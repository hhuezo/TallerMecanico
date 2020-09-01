using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo.DB.Exceptions;
using System.Threading;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace TallerMecanico.Module.BusinessObjects.Configuracion
{
    [DefaultClassOptions]
    [ImageName("Numbers-icon")]
    [NavigationItem("Configuración")]
    [ModelDefault("Caption", "Secuencias")]

    public sealed class Secuencias : XPBaseObject
    {
        // use GUID keys to prepare your database for replication
        private string _SequencePrefix;
        [Key(true)]
        public Guid Oid;

        [Appearance("Secuencias.SequencePrefix", Enabled = false)]
        [ModelDefault("Caption", "Entidad")]
        [Size(254), Indexed(Unique = true)]
        public string SequencePrefix
        {
            get
            {
                return _SequencePrefix;
            }
            set
            {
                SetPropertyValue("SequencePrefix", ref _SequencePrefix, value);
            }
        }


        [ModelDefault("Caption", "Contador")]
        public int Counter;
        public Secuencias(Session session) : base(session) { }
        public const int MaxIdGenerationAttempts = 7;
        public const int MinConflictDelay = 50;
        public const int MaxConflictDelay = 500;
        public static int GetNextValue(IDataLayer dataLayer, string sequencePrefix)
        {
            if (dataLayer == null)
                throw new ArgumentNullException("dataLayer");
            if (sequencePrefix == null)
                sequencePrefix = string.Empty;

            int attempt = 1;
            while (true)
            {
                try
                {
                    using (Session generatorSession = new Session(dataLayer))
                    {
                        Secuencias generator = generatorSession.FindObject<Secuencias>(new OperandProperty("SequencePrefix") == sequencePrefix);
                        if (generator == null)
                        {
                            generator = new Secuencias(generatorSession);
                            generator.SequencePrefix = sequencePrefix;
                        }
                        generator.Counter++;
                        generator.Save();
                        return generator.Counter;
                    }
                }
                catch (LockingException)
                {
                    if (attempt >= MaxIdGenerationAttempts)
                        throw;
                }
                if (attempt > MaxIdGenerationAttempts / 2)
                    Thread.Sleep(new Random().Next(MinConflictDelay, MaxConflictDelay));

                attempt++;
            }
        }
        public static int GetNextValue(string sequencePrefix)
        {
            return GetNextValue(sequencePrefix);
        }
    }
}
