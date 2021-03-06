# Postgres 年季月周日条件过滤

## 年

```sql
-- 本年
to_char(<COLUMN>, 'yyyy') = to_char(now(), 'yyyy')

-- 去年
to_char(<COLUMN>, 'yyyy') = to_char(now() - interval '1' year, 'yyyy')

-- 前年
to_char(<COLUMN>, 'yyyy') = to_char(now() - interval '2' year, 'yyyy')

-- 3年前（不包含当年）
to_char(<COLUMN>, 'yyyy') >= to_char(now() - interval '3' year, 'yyyy') and to_char(<COLUMN>, 'yyyy') < to_char(now(), 'yyyy')

-- 3年之内（包含当年）
to_char(<COLUMN>, 'yyyy') >= to_char(now() - interval '2' year, 'yyyy')
```

## 季度

```sql
-- 本季度
to_char(<COLUMN>, 'yyyy-Q') = to_char(now(), 'yyyy-Q')

-- 上季度
to_char(<COLUMN>, 'yyyy-Q') = to_char(now() - interval '3' month, 'yyyy-Q')

-- 3季度前（不包含当季度）
to_char(<COLUMN>, 'yyyy-Q') >= to_char(now() - interval '9' month, 'yyyy-Q') and to_char(<COLUMN>, 'yyyy-Q') < to_char(now(), 'yyyy-Q')

-- 3季度之内（包含当季度）
to_char(<COLUMN>, 'yyyy-Q') >= to_char(now() - interval '6' month, 'yyyy-Q')
```

## 月

```sql
-- 本月
to_char(<COLUMN>, 'yyyy-MM') = to_char(now(), 'yyyy-MM')

-- 上月
to_char(<COLUMN>, 'yyyy-MM') = to_char(now() - interval '1' month, 'yyyy-MM')

-- 3月前（不包含当月）
to_char(<COLUMN>, 'yyyy-MM') >= to_char(now() - interval '3' month, 'yyyy-MM') and to_char(<COLUMN>, 'yyyy-MM') < to_char(now(), 'yyyy-MM')

-- 3月之内（包含当月）
to_char(<COLUMN>, 'yyyy-MM') >= to_char(now() - interval '2' month, 'yyyy-MM')
```

## 日

```sql
-- 今天
to_char(<COLUMN>, 'yyyy-MM-dd') = to_char(now(), 'yyyy-MM-dd')

-- 昨天
to_char(<COLUMN>, 'yyyy-MM-dd') = to_char(now() - interval '1' day, 'yyyy-MM-dd')

-- 近7天
to_char(<COLUMN>, 'yyyy-MM-dd') >= to_char(now() - interval '6' day, 'yyyy-MM-dd')

-- 近30天
to_char(<COLUMN>, 'yyyy-MM-dd') >= to_char(now() - interval '29' day, 'yyyy-MM-dd')

-- 10天前（不包含当天）
to_char(<COLUMN>, 'yyyy-MM-dd') >= to_char(now() - interval '10' day, 'yyyy-MM-dd') and to_char(<COLUMN>, 'yyyy-MM-dd') < to_char(now(), 'yyyy-MM-dd')

-- 10天之内（包含当天）
to_char(<COLUMN>, 'yyyy-MM-dd') >= to_char(now() - interval '9' day, 'yyyy-MM-dd')
```

## 时

```sql
-- 近24小时
<COLUMN> >= now() - interval '23' hour;
```
