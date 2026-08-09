SELECT `s`.`Id` AS `shelterId`, `s`.`Name` AS `shelterName`, `s`.`Capacity` AS `capacity`, `a`.`City` AS `city`, `a`.`Neighborhood` AS `neighborhood`
      FROM `Shelters` AS `s`
      INNER JOIN `Areas` AS `a` ON `s`.`AreaId` = `a`.`Id`

SELECT `s`.`Id` AS `id`, `s`.`Name` AS `name`, `s`.`Street` AS `street`, `s`.`Capacity` AS `capacity`, `s`.`IsAccessible` AS `isAccessible`, `a`.`City` AS `city`
      FROM `Shelters` AS `s`
      INNER JOIN `Areas` AS `a` ON `s`.`AreaId` = `a`.`Id`
      WHERE ((LOWER(`a`.`City`) = @__city_0) AND (`s`.`Capacity` >= @__minCapacity_1)) AND `s`.`IsPublic`

SELECT `s`.`Id`, `s`.`Name`, `s`.`Street`, `s`.`BuildingNumber`, `s`.`Capacity`, `s`.`IsAccessible`, `s`.`IsPublic`, `s`.`ShelterType`
      FROM `Shelters` AS `s`
      ORDER BY `s`.`Name` DESC

SELECT `i`.`Id` AS `inspectionId`, `i`.`InspectionDate` AS `inspectionDate`, CAST(`i`.`ReadinessScore` AS double) AS `readinessScore`, `i`.`Passed` AS `passed`, `s`.`Name` AS `shelterName`, `a`.`City` AS `city`, `a`.`Neighborhood` AS `neighborhood`
      FROM `Inspections` AS `i`
      INNER JOIN `Shelters` AS `s` ON `i`.`ShelterId` = `s`.`Id`
      INNER JOIN `Areas` AS `a` ON `s`.`AreaId` = `a`.`Id

SELECT `s`.`Id` AS `shelterId`, `s`.`Name` AS `shelterName`, (
          SELECT COUNT(*)
          FROM `Inspections` AS `i`
          WHERE `s`.`Id` = `i`.`ShelterId`) AS `inspectionCount`
      FROM `Shelters` AS `s`