SELECT `s`.`Id` AS `shelterId`, `s`.`Name` AS `shelterName`, `s`.`Capacity` AS `capacity`, `a`.`City` AS `city`, `a`.`Neighborhood` AS `neighborhood`
      FROM `Shelters` AS `s`
      INNER JOIN `Areas` AS `a` ON `s`.`AreaId` = `a`.`Id`

SELECT `s`.`Id` AS `id`, `s`.`Name` AS `name`, `s`.`Street` AS `street`, `s`.`Capacity` AS `capacity`, `s`.`IsAccessible` AS `isAccessible`, `a`.`City` AS `city`
      FROM `Shelters` AS `s`
      INNER JOIN `Areas` AS `a` ON `s`.`AreaId` = `a`.`Id`
      WHERE ((LOWER(`a`.`City`) = @__city_0) AND (`s`.`Capacity` >= @__minCapacity_1)) AND `s`.`IsPublic`