FROM postgres:16.6-alpine

COPY docker-entrypoint-initdb.d/001-make-vulnfeed-db.sql /docker-entrypoint-initdb.d/001-make-vulnfeed-db.sql
COPY docker-entrypoint-initdb.d/002-make-subscription-db.sql /docker-entrypoint-initdb.d/002-make-subscription-db.sql
