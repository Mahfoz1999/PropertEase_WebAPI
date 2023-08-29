﻿// This file was auto-generated by ML.NET Model Builder.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML;
using System.Data.SqlClient;
using Microsoft.ML.Data;

namespace PropertEase_Commends
{
    public partial class PropertyValuePrediction
    {
        public const string RetrainConnectionString = @"Data Source=DESKTOP-S7P487B;Initial Catalog=PropertEaseDB;Integrated Security=True";
        public const string RetrainCommandString = @"SELECT CAST([Id] as REAL), CAST([Area] as NVARCHAR(MAX)), CAST([Quality] as NVARCHAR(MAX)), CAST([Latitude] as REAL), CAST([Longitude] as REAL), CAST([Price] as REAL), CAST([SizeInSqft] as REAL), CAST([PricePerSqft] as REAL), CAST([NoOfBedrooms] as REAL), CAST([NoOfBathrooms] as REAL), [MaidRoom], [UnFurnished], [Balcony], [BarbecueArea], [BuiltInWardrobes], [CentralAc], [ChildrensPlayArea], [ChildrensPool], [Concierge], [CoveredParking], [KitchenAppliances], [LobbyInBuilding], [MaidService], [Networked], [PetsAllowed], [PrivateGarden], [PrivateGym], [PrivateJacuzzi], [PrivatePool], [Security], [SharedGym], [Study], [SharedPool], [SharedSpa], [VastuCompliant], [ViewOfLandmark], [ViewOfWater], [WalkInCloset] FROM [dbo].[Properties]";

        /// <summary>
        /// Train a new model with the provided dataset.
        /// </summary>
        /// <param name="outputModelPath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet"</param>
        /// <param name="connectionString">Connection string for databases on-premises or in the cloud.</param>
        /// <param name="commandText">Command string for selecting training data.</param>
        public static void Train(string outputModelPath, string connectionString = RetrainConnectionString, string commandText = RetrainCommandString)
        {
            var mlContext = new MLContext();

            var data = LoadIDataViewFromDatabase(mlContext, connectionString, commandText);
            var model = RetrainModel(mlContext, data);
            SaveModel(mlContext, model, data, outputModelPath);
        }

        /// <summary>
        /// Load an IDataView from a database source.For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="connectionString">Connection string for databases on-premises or in the cloud.</param>
        /// <param name="commandText">Command string for selecting training data.</param>
        /// <returns>IDataView with loaded training data.</returns>
        public static IDataView LoadIDataViewFromDatabase(MLContext mlContext, string connectionString, string commandText)
        {
            DatabaseLoader loader = mlContext.Data.CreateDatabaseLoader<ModelInput>();
            DatabaseSource dbSource = new DatabaseSource(SqlClientFactory.Instance, connectionString, commandText);

            return loader.Load(dbSource);
        }

        /// <summary>
        /// Save a model at the specified path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="model">Model to save.</param>
        /// <param name="data">IDataView used to train the model.</param>
        /// <param name="modelSavePath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet.</param>
        public static void SaveModel(MLContext mlContext, ITransformer model, IDataView data, string modelSavePath)
        {
            // Pull the data schema from the IDataView used for training the model
            DataViewSchema dataViewSchema = data.Schema;

            using (var fs = File.Create(modelSavePath))
            {
                mlContext.Model.Save(model, dataViewSchema, fs);
            }
        }


        /// <summary>
        /// Retrain model using the pipeline generated as part of the training process.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainModel(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new []{new InputOutputColumnPair(@"Quality", @"Quality"),new InputOutputColumnPair(@"MaidRoom", @"MaidRoom"),new InputOutputColumnPair(@"UnFurnished", @"UnFurnished"),new InputOutputColumnPair(@"Balcony", @"Balcony"),new InputOutputColumnPair(@"BarbecueArea", @"BarbecueArea"),new InputOutputColumnPair(@"BuiltInWardrobes", @"BuiltInWardrobes"),new InputOutputColumnPair(@"CentralAc", @"CentralAc"),new InputOutputColumnPair(@"ChildrensPlayArea", @"ChildrensPlayArea"),new InputOutputColumnPair(@"ChildrensPool", @"ChildrensPool"),new InputOutputColumnPair(@"Concierge", @"Concierge"),new InputOutputColumnPair(@"CoveredParking", @"CoveredParking"),new InputOutputColumnPair(@"KitchenAppliances", @"KitchenAppliances"),new InputOutputColumnPair(@"LobbyInBuilding", @"LobbyInBuilding"),new InputOutputColumnPair(@"MaidService", @"MaidService"),new InputOutputColumnPair(@"Networked", @"Networked"),new InputOutputColumnPair(@"PetsAllowed", @"PetsAllowed"),new InputOutputColumnPair(@"PrivateGarden", @"PrivateGarden"),new InputOutputColumnPair(@"PrivateGym", @"PrivateGym"),new InputOutputColumnPair(@"PrivateJacuzzi", @"PrivateJacuzzi"),new InputOutputColumnPair(@"PrivatePool", @"PrivatePool"),new InputOutputColumnPair(@"Security", @"Security"),new InputOutputColumnPair(@"SharedGym", @"SharedGym"),new InputOutputColumnPair(@"Study", @"Study"),new InputOutputColumnPair(@"SharedPool", @"SharedPool"),new InputOutputColumnPair(@"SharedSpa", @"SharedSpa"),new InputOutputColumnPair(@"VastuCompliant", @"VastuCompliant"),new InputOutputColumnPair(@"ViewOfLandmark", @"ViewOfLandmark"),new InputOutputColumnPair(@"ViewOfWater", @"ViewOfWater"),new InputOutputColumnPair(@"WalkInCloset", @"WalkInCloset")}, outputKind: OneHotEncodingEstimator.OutputKind.Indicator)      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Id", @"Id"),new InputOutputColumnPair(@"Latitude", @"Latitude"),new InputOutputColumnPair(@"Longitude", @"Longitude"),new InputOutputColumnPair(@"SizeInSqft", @"SizeInSqft"),new InputOutputColumnPair(@"PricePerSqft", @"PricePerSqft"),new InputOutputColumnPair(@"NoOfBedrooms", @"NoOfBedrooms"),new InputOutputColumnPair(@"NoOfBathrooms", @"NoOfBathrooms")}))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"Area",outputColumnName:@"Area"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Quality",@"MaidRoom",@"UnFurnished",@"Balcony",@"BarbecueArea",@"BuiltInWardrobes",@"CentralAc",@"ChildrensPlayArea",@"ChildrensPool",@"Concierge",@"CoveredParking",@"KitchenAppliances",@"LobbyInBuilding",@"MaidService",@"Networked",@"PetsAllowed",@"PrivateGarden",@"PrivateGym",@"PrivateJacuzzi",@"PrivatePool",@"Security",@"SharedGym",@"Study",@"SharedPool",@"SharedSpa",@"VastuCompliant",@"ViewOfLandmark",@"ViewOfWater",@"WalkInCloset",@"Id",@"Latitude",@"Longitude",@"SizeInSqft",@"PricePerSqft",@"NoOfBedrooms",@"NoOfBathrooms",@"Area"}))      
                                    .Append(mlContext.Regression.Trainers.FastForest(new FastForestRegressionTrainer.Options(){NumberOfTrees=4,NumberOfLeaves=4,FeatureFraction=1F,LabelColumnName=@"Price",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
 }
