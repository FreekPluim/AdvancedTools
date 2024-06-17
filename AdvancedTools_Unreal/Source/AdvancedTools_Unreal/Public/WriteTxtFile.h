// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "WriteTxtFile.generated.h"

/**
 * 
 */
UCLASS()
class ADVANCEDTOOLS_UNREAL_API UWriteTxtFile : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()
	
public:

	UFUNCTION(BlueprintPure, Category = "Custom", meta = (Keywords = "LoadTxt"))
		static bool LoadTxt(FString FileNameA, FString& SaveTextA);

	UFUNCTION(BlueprintCallable, Category = "Custom", meta = (Keywords = "ArrayToString", ArrayParm = "TargetArray"))
		static FString ArrayToString(const TArray<int32>& Array, int arrayCount);

	UFUNCTION(BlueprintCallable, Category = "Custom", meta = (Keywords = "GetAverage", ArrayParm = "TargetArray"))
		static FString GetAverage(const TArray<int32>& Array, int arrayCount, int objectsAmount);

	UFUNCTION(BlueprintCallable, Category = "Custom", meta = (Keywords = "SaveTxt"))
		static bool SaveTxt(FString SaveTextB, FString FileNameB);
};
