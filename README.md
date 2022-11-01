# Backend-coding-challenge

## Project

REST API for querying population data for differents states using:  
https://datausa.io/api/

Also saving all queries made with datetime in a in-memory database and providing a way to access this information.

---

## Dependencies

### Frameworks

| Framework | Version |
| --------- | ------- |
| .NETcore  | 5.0.0   |

### Package dependencies

| Package                                | Version |
| -------------------------------------- | ------- |
| Microsoft.EntityFrameworkCore.InMemory | 5.0.17  |
| Newtonsoft.Json                        | 13.0.1  |
| Swashbuckle.AspNetCore                 | 5.6.3   |

### Project dependencies

| Project    | Dependency |
| ---------- | ---------- |
| Contracts  | Entities   |
| DataUSA    | Entities   |
| DataUSA    | Repository |
| Repository | Contracts  |

---

# Endpoints

## Data

**Get all population data.**

**_Every available year_**

```css
/api/Data
```

**_Latest available year_**

```css
/api/Data?latest=true
```

#

**Compare the population data for two states.**

**_Latest available year_**

```css
/api/Data/StateComparison?state1=[state]&state2=[state]
```

**_Specific year_**

```css
/api/Data/StateComparison?state1=[state]&state2=[state]&year=[year]
```

**_Every available year_**

```css
/api/Data/StateComparison?state1=[state]&state2=[state]&latest=false
```

#

**Get population data for the state with the biggest/smallest population.**

**_Latest available year_**

```css
/api/Data/Size?type=[biggest/smallest]
```

**_Specific year_**

```css
/api/Data/Size?type=[biggest/smallest]&year=[year]
```

#

**Get population data for a specific state.**

**_Latest available year_**

```css
/api/Data/[state]
```

**_Specific year_**

```css
/api/Data/[state]?year=[year]
```

#

**Get historic population data for a specific state.**

**_All data between two specific years_**

```css
/api/Data/StateHistory?state=[state]&startYear=[year]&endYear=[year]
```

## Querylogs

**Get all querylogs**

```css
/api/QueryLog
```

**Get a specific querylog by ID**

```css
/api/QueryLog/[id]
```
