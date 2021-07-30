using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using IndianCensusAnalyser.DTO;
using IndianCensusAnalyser;

namespace UnitTestForIndianCensus
{
    [TestClass]
    public class UnitTest1
    {
        
        string stateCensusPath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        string wrongCensusPath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateData.csv";
        string wrongTypeStateCodePath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongHeaderStateCensusPath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string delimiterStateCensusPath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        
        string stateCodePath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndianStateCode.csv";
        string wrongStateCodePath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaCode.csv";
        string wrongHeaderStateCodePath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        string delimiterStateCodePath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";

        IndianCensusAnalyser.CSVAdapterFactory CSV = null;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;

        [TestInitialize]
        public void SetUp()
        {
            CSV = new IndianCensusAnalyser.CSVAdapterFactory();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }
        //TC 1.1
        [TestCategory("Use Case 1")]
        [TestMethod]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            stateRecords = CSV.LoadCsvData(IndianCensusAnalyser.CensusAnalyser.Country.INDIA,stateCensusPath, "State,Population,AreaInSqkm,DensityPerSqkm");
            Assert.AreEqual(7, stateRecords.Count);
        }
        //TC 1.2
        [TestCategory("Use Case 1")]
        [TestMethod]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, "State,Population,AreaInSqkm,DensityPerSqkm"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        //TC 1.3
        [TestCategory("Use Case 1")]
        [TestMethod]
        public void GivenWrongTypeReturnsCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNO,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
        }
        //TC 1.4
        [TestCategory("Use Case 1")]
        [TestMethod]
        public void GivenWrongDelimeterReturnCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, "State,Population,AreaInSqkm,DensityPerSqkm"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
        }
        //TC 1.5
        [TestCategory("Use Case 1")]
        [TestMethod]
        public void GivenWrongHeaderReturnsCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, "State,Population,AreaInSqkm,DensityPerSqkm"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
        }
        //TC 2.1
        [TestCategory("Use Case 2")]
        [TestMethod]
        public void GivenStateCodeReturnCount()
        {
            totalRecords = CSV.LoadCsvData(IndianCensusAnalyser.CensusAnalyser.Country.INDIA, stateCodePath, "SrNO,State Name,TIN,StateCode");
            Assert.AreEqual(5,totalRecords.Count);
        }
        //TC 2.2
        [TestCategory("Use Case 2")]
        [TestMethod]
        public void GivenIncorrectPathShouldThrowCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodePath, "State,Population,AreaInSqkm,DensityPerSqkm"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        //TC 2.3
        [TestCategory("Use Case 2")]
        [TestMethod]
        public void GivenWrongTypeForStateCodeReturnsCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNO,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
        }
        //TC 2.4
        [TestCategory("Use Case 2")]
        [TestMethod]
        public void GivenWrongDelimeterForStateCodeReturnCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCodePath, "SrNO,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
        }
        //TC 2.5
        [TestCategory("Use Case 2")]
        [TestMethod]
        public void GivenWrongHeaderForStateCodeReturnsCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodePath, "SrNO,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
        }
    }
}
 