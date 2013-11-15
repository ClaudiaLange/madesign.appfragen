﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using af.contracts;
using af.ui;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace af.ui.test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod, Ignore]
        public void TestStarten()
        {
            dynamic expandoObject = new ExpandoObject();
            expandoObject.cmd = "Starten";

            // Json functionality available after NuGet installation and deinstallation of Microsoft.AspNet.Web.Helpers.Mvc 2.0.20710
            // System.Web.helpers v1.0.20105.407 is now available in lib-dir - but also not needed as reference.
            var json = jsonserialization.JsonExtensions.ToJson(expandoObject);
            Console.WriteLine(json);
            //jsonObject.ToJson();

            var ui = new Ui();
            ui.Process(json);
        }

        [TestMethod, Ignore]
        public void TestFragebogenAnzeigen()
        {
            dynamic expandoObject = new ExpandoObject();
            expandoObject.cmd = "Fragebogen anzeigen";
            
            var befragung = new Befragung();
            befragung.Reset();
            befragung.Fragen.Add(
                new Befragung.Frage
                    {
                        Text = "Was ist kein Säugetier?",
                        Antwortmöglichkeiten = new List<Befragung.Antwortmöglichkeit>
                            {
                                new Befragung.Antwortmöglichkeit
                                    {
                                        Id = "F1A1",
                                        Text = "Hund"
                                    },
                                new Befragung.Antwortmöglichkeit
                                    {
                                        Id = "F1A2",
                                        Text = "Katze"
                                    },
                                new Befragung.Antwortmöglichkeit
                                    {
                                        Id = "F1A3",
                                        Text = "Fisch",
                                        IstRichtigeAntwort = true
                                    },
                                new Befragung.Antwortmöglichkeit
                                    {
                                        Id = "F1A4",
                                        Text = "Weiß nicht"
                                    },
                            }
                    });

            expandoObject.payload = new ExpandoObject();
            expandoObject.payload.Fragen = new List<ExpandoObject>();
            dynamic frage = new ExpandoObject();
            frage.Text = "Was ist kein Säugetier?";
            //frage.Antwortmöglichkeiten = new List<ExpandoObject>();
            //frage.Antwortmöglichkeiten.Add( ErstelleAntwortmöglichkeit("F1A1", "Hund"));
            //frage.Antwortmöglichkeiten.Add( ErstelleAntwortmöglichkeit( "F1A2", "Katze" ) );
            //frage.Antwortmöglichkeiten.Add( ErstelleAntwortmöglichkeit( "F1A3", "Fisch" ) );
            //frage.Antwortmöglichkeiten.Add( ErstelleAntwortmöglichkeit( "F1A4", "Weiß nicht" ) );
            expandoObject.payload.Fragen.Add( frage );

            //"Fragen": [
            //    {
            //        "Text": "<fragetext>",
            //        "Antwortmoeglichkeiten": [
            //            {
            //                "Id": "<id>",
            //                "Text": "<antwortmoeglichkeitentext>",
            //                "Ausgewaehlt": true, // oder false
            //            },
            //            ...
            //        ]
            //    },
            //    ...
            //]

            var json = jsonserialization.JsonExtensions.ToJson( expandoObject );
            var ui = new Ui();
            ui.Process( json );
        }

        private ExpandoObject ErstelleAntwortmöglichkeit( string id, string text, bool isAntwort = false )
        {
            dynamic ant = new ExpandoObject();
            ant.Id = id;
            ant.Text = text;
            ant.IstRichtigeAntwort = isAntwort;

            return ant;
        }
    }
}
