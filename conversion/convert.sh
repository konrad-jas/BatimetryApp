#!/bin/bash
gdal_translate -of GTiff -ot Byte -scale 0 65535 0 255 B02.jp2 blue.tif
