using Laixer.Kadaster.Entities;
using Laixer.Kadaster.Entities.Embed;
using System;
using System.Collections.Generic;

namespace Laixer.Kadaster.UnitTests
{
    internal static class EntityRepository
    {
        #region Premises
        public static List<Premise> Premises = new List<Premise>
        {
            new Premise
            {
                Id = "1895100000022868",
                BuiltYear = 1992,
                Status = "PandInGebruik",
                Links = new PremiseResourceConnection
                {
                    Self = new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/panden/1895100000022868"),
                    },
                    Occurrence = new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/panden/1895100000022868/voorkomens"),
                    },
                    ResidentialObject= new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/verblijfsobjecten?pandrelatering=1895100000022868"),
                    },
                },
                Embed = new EmbeddingGeometry
                {
                    Geometry = new Geometry
                    {
                        Coordination = new List<List<List<double>>>
                        {
                            new List<List<double>>
                            {
                                new List<double>
                                {
                                    7.014842,
                                    53.1878768
                                },
                                new List<double>
                                {
                                    7.0148318,
                                    53.1879254
                                },
                                new List<double>
                                {
                                    7.0146864,
                                    53.1879144
                                },
                                new List<double>
                                {
                                    7.0146872,
                                    53.1879108
                                },
                                new List<double>
                                {
                                    7.0146311,
                                    53.1879066
                                },
                                new List<double>
                                {
                                    7.0146376,
                                    53.1878759
                                },
                                new List<double>
                                {
                                    7.0146472,
                                    53.1878767
                                },
                                new List<double>
                                {
                                    7.0146545,
                                    53.1878418
                                },
                                new List<double>
                                {
                                    7.0146493,
                                    53.1878414
                                },
                                new List<double>
                                {
                                    7.0146571,
                                    53.1878041
                                },
                                new List<double>
                                {
                                    7.0147088,
                                    53.187808
                                },
                                new List<double>
                                {
                                    7.0147095,
                                    53.1878045
                                },
                                new List<double>
                                {
                                    7.0148404,
                                    53.1878144
                                },
                                new List<double>
                                {
                                    7.0148276,
                                    53.1878757
                                },
                                new List<double>
                                {
                                    7.014842,
                                    53.1878768
                                },
                            }
                        },
                        Type = "Polyon",
                        Crs = new Geometry.GeometryCrs
                        {
                            Type = "name"
                        }
                    },
                    Occurrence = new Occurrence
                    {
                        ValidFrom = "1998-11-11T00:00:00.000+01:00",
                        ValidTil = null,
                        UnderInvestigation = false,
                        Established = false,
                        AppointmentActive = false,
                        AppointmentCorrection = 0,
                        Embed = new EmbeddingSource
                        {
                            Source = new Source
                            {
                                DocumentId = "98239",
                                DocumentDate = "1998-11-11",
                            }
                        }
                    }
                }
            },
            new Premise
            {
                Id = "0703100000022427",
                BuiltYear = 1880,
                Status = "PandInGebruik",
                Links = new PremiseResourceConnection
                {
                    Self = new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/panden/0703100000022427"),
                    },
                    Occurrence = new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/panden/0703100000022427/voorkomens"),
                    },
                    ResidentialObject= new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/verblijfsobjecten?pandrelatering=0703100000022427"),
                    },
                },
                Embed = new EmbeddingGeometry
                {
                    Geometry = new Geometry
                    {
                        Coordination = new List<List<List<double>>>
                        {
                            new List<List<double>>
                            {
                                new List<double>
                                {
                                    4.1129862,
                                    51.4336513
                                },
                                new List<double>
                                {
                                    4.1130098,
                                    51.433723
                                },
                                new List<double>
                                {
                                    4.1129002,
                                    51.4337371
                                },
                                new List<double>
                                {
                                    4.1128824,
                                    51.4336831
                                },
                                new List<double>
                                {
                                    4.1129131,
                                    51.4336791
                                },
                                new List<double>
                                {
                                    7.0148404,
                                    53.1878144
                                },
                                new List<double>
                                {
                                    4.1129072,
                                    51.4336612
                                },
                                new List<double>
                                {
                                    4.1129862,
                                    51.4336513
                                },
                            }
                        },
                        Type = "Polyon",
                        Crs = new Geometry.GeometryCrs
                        {
                            Type = "name"
                        }
                    },
                    Occurrence = new Occurrence
                    {
                        ValidFrom = "1973-09-25T00:00:00.010+01:00",
                        ValidTil = null,
                        UnderInvestigation = false,
                        Established = false,
                        AppointmentActive = false,
                        AppointmentCorrection = 0,
                        // FUTURE: Has undocumented 'Label'
                        Embed = new EmbeddingSource
                        {
                            Source = new Source
                            {
                                DocumentId = "1973/356",
                                DocumentDate = "1973-09-25",
                            }
                        }
                    }
                }
            },
            new Premise
            {
                Id = "0703100000025398",
                BuiltYear = 2010,
                Status = "PandGesloopt",
                Links = new PremiseResourceConnection
                {
                    Self = new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/panden/0703100000025398"),
                    },
                    Occurrence = new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/panden/0703100000025398/voorkomens"),
                    },
                    ResidentialObject= new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/verblijfsobjecten?pandrelatering=0703100000025398"),
                    },
                },
                Embed = new EmbeddingGeometry
                {
                    Geometry = new Geometry
                    {
                        Coordination = new List<List<List<double>>>
                        {
                            new List<List<double>>
                            {
                                new List<double>
                                {
                                    4.2497841,
                                    51.3780197
                                },
                                new List<double>
                                {
                                    4.2497346,
                                    51.3780527
                                },
                                new List<double>
                                {
                                    4.2494813,
                                    51.3779044
                                },
                                new List<double>
                                {
                                    4.2495308,
                                    51.3778714
                                },
                                new List<double>
                                {
                                    4.2497841,
                                    51.3780197
                                },
                            }
                        },
                        Type = "Polyon",
                        Crs = new Geometry.GeometryCrs
                        {
                            Type = "name"
                        }
                    },
                    Occurrence = new Occurrence
                    {
                        ValidFrom = "2012-02-02T02:00:00.030+01:00",
                        ValidTil = null,
                        UnderInvestigation = false,
                        Established = false,
                        AppointmentActive = false,
                        AppointmentCorrection = 0,
                        // FUTURE: Has undocumented 'Label'
                        Embed = new EmbeddingSource
                        {
                            Source = new Source
                            {
                                DocumentId = "12.003511",
                                DocumentDate = "2012-02-02",
                            }
                        }
                    }
                }
            },
            new Premise
            {
                Id = "1525100000000739",
                BuiltYear = 1950,
                Status = "PandGesloopt",
                Links = new PremiseResourceConnection
                {
                    Self = new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/panden/1525100000000739"),
                    },
                    Occurrence = new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/panden/1525100000000739/voorkomens"),
                    },
                    ResidentialObject= new ResourceConnection
                    {
                        Href = new Uri(MockEndpointProcedure.BaseUrl + "/verblijfsobjecten?pandrelatering=1525100000000739"),
                    },
                },
                Embed = new EmbeddingGeometry
                {
                    Geometry = new Geometry
                    {
                        Coordination = new List<List<List<double>>>
                        {
                            new List<List<double>>
                            {
                                new List<double>
                                {
                                    4.5127235,
                                    52.2206578
                                },
                                new List<double>
                                {
                                    4.5124245,
                                    52.2205012
                                },
                                new List<double>
                                {
                                    4.512509,
                                    52.2204403
                                },
                                new List<double>
                                {
                                    4.5128157,
                                    52.2206003
                                },
                                new List<double>
                                {
                                    4.5127309,
                                    52.2206616
                                },
                                new List<double>
                                {
                                    4.5127235,
                                    52.2206578
                                },
                            }
                        },
                        Type = "Polyon",
                        Crs = new Geometry.GeometryCrs
                        {
                            Type = "name"
                        }
                    },
                    Occurrence = new Occurrence
                    {
                        ValidFrom = "2017-11-10T00:00:00.000+01:00",
                        ValidTil = null,
                        UnderInvestigation = false,
                        Established = false,
                        AppointmentActive = false,
                        AppointmentCorrection = 0,
                        // FUTURE: Has undocumented 'Label'
                        Embed = new EmbeddingSource
                        {
                            Source = new Source
                            {
                                DocumentId = "Z-17-001708/D-57692",
                                DocumentDate = "2017-11-10",
                            }
                        }
                    }
                }
            },
        };
        #endregion
    }
}
