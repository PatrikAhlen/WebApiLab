using System;
using System.Collections.Generic;
using SCB.Hermes.Contract.External;

namespace WebApiLab.Store
{
    public class Data
    {
        private List<Recipient> _recipients = new List<Recipient>();
        private static Data _instance;
        private IEnumerable<Variable> _variables;

        public static Data GetInstance
        {
            get { return _instance ??= new Data(); }
        }

        public Data()
        {
            GenerateRecipients();
            GenerateVariables();
        }

        private void GenerateVariables()
        {
            _variables = new List<Variable>
            {
                new Variable
                {
                    Name = "Personnnummer",
                    DataType = DataType.String,
                    ShortName = "PersNr",
                    PresentationText = "Ett personnummer"
                },
                new Variable
                {
                    Name = "Antal Julklappar",
                    DataType = DataType.Int,
                    ShortName = "AntalJulklappar",
                    Definition = "antal julklappar",
                    PresentationText = "antal julklappar du fick förra julen"
                }
            };
        }

        public List<Recipient> Recipients
        {
            get
            {
                if (_recipients == null)
                {
                    GenerateRecipients();
                }
                return _recipients;

            }
        }

        public IEnumerable<Variable> Variables => _variables;

        private void GenerateRecipients()
        {
            for (int i = 0; i < 100; i++)
            {
                _recipients.Add(new Recipient
                {
                    ScbId = $"scbid_{i}",
                    VariableValues = new List<VariableValue>
                    {
                        new VariableValue
                        {
                            ShortName = "PersNr",
                            Value = $"790101-0{i}"
                        },
                        new VariableValue
                        {
                            ShortName = "AntalJulklappar",
                            Value = i.ToString()
                        }
                    }
                });
            }
        }
    }
}