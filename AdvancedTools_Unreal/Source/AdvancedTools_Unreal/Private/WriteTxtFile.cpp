// Fill out your copyright notice in the Description page of Project Settings.


#include "WriteTxtFile.h"

bool UWriteTxtFile::LoadTxt(FString FileNameA, FString& SaveTextA)
{
    return FFileHelper::LoadFileToString(SaveTextA, *(FPaths::ProjectDir() + "/ResearchData/" + FileNameA + ".txt"));
}

FString UWriteTxtFile::ArrayToString(const TArray<int32>& Array, int arrayCount)
{
	FString tempString = "FPS:\n\n";
	int total = 0;

	for (int32 i = 0; i < arrayCount; i++)
	{
		tempString += FString::FromInt(Array[i]) + "\n";
		total += Array[i];
	}

	int average = round(total / arrayCount);

	tempString += "\nAverage: " + FString::FromInt(average);

	return tempString;
}

FString UWriteTxtFile::GetAverage(const TArray<int32>& Array, int arrayCount, int objectsAmount)
{
	FString tempString = FString::FromInt(objectsAmount);
	int total = 0;

	for (int32 i = 0; i < arrayCount; i++)
	{
		total += Array[i];
	}

	int average = round(total / arrayCount);

	tempString += " - " + FString::FromInt(average) + "\n";

	return tempString;
}

bool UWriteTxtFile::SaveTxt(FString SaveTextB, FString FileNameB)
{
    return FFileHelper::SaveStringToFile(SaveTextB, *(FPaths::ProjectDir() + "/ResearchData/" + FileNameB + ".txt"));
}