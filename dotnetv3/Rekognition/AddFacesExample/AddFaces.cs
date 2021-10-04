﻿// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier:  Apache-2.0

namespace AddFacesExample
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Amazon.Rekognition;
    using Amazon.Rekognition.Model;

    /// <summary>
    /// Uses the Amazon Rekognition Service to detect faces in an image and
    /// then adds the information to a collection. The example was created
    /// using the AWS SDK for .NET and .NET Core 5.0.
    /// </summary>
    public class AddFaces
    {
        // snippet-start:[Rekognition.dotnetv3.AddFacesExample]
        public static async Task Main()
        {
            string collectionId = "MyCollection2";
            string bucket = "doc-example-bucket";
            string photo = "input.jpg";

            var rekognitionClient = new AmazonRekognitionClient();

            var image = new Image
            {
                S3Object = new S3Object
                {
                    Bucket = bucket,
                    Name = photo,
                },
            };

            IndexFacesRequest indexFacesRequest = new IndexFacesRequest()
            {
                Image = image,
                CollectionId = collectionId,
                ExternalImageId = photo,
                DetectionAttributes = new List<string>() { "ALL" },
            };

            IndexFacesResponse indexFacesResponse = await rekognitionClient.IndexFacesAsync(indexFacesRequest);

            Console.WriteLine($"{photo} added");
            foreach (FaceRecord faceRecord in indexFacesResponse.FaceRecords)
            {
                Console.WriteLine($"Face detected: Faceid is {faceRecord.Face.FaceId}");
            }
        }

        // snippet-end:[Rekognition.dotnetv3.AddFacesExample]
    }
}
