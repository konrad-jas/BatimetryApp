import rasterio
import numpy as np
import itertools as it

def openImage(imageName):
    with rasterio.open(imageName) as image:
        return image.read(1)

def saveImage(imageData, dataWidth, dataHeight):
    with rasterio.open("result2.tif", 'w', width=dataWidth, height=dataHeight, driver="GTiff", count=1,
                       dtype=rasterio.uint8) as result:	
        result.write(imageData.astype(rasterio.uint8), 1)

with rasterio.open("blue.tif") as im:
    imgWidth = im.width
    imgHeight = im.height

blueBand = openImage("blue.tif")
greenBand = openImage("green.tif")
mask = np.array(openImage("mask.tif"))

blueArr = np.array(blueBand)
greenArr = np.array(greenBand)
result = np.zeros(blueBand.shape)

blueArr[blueArr == 0] = 1
greenArr[greenArr == 0] = 1

result = 22.1584 * (np.log(greenArr)/np.log(blueArr)) - 22.94
#for resultO, blueO, greenO, maskedO in it.izip(result, blueArr, greenArr, mask):
#    for result, blue, green, masked in it.izip(resultO, blueO, greenO, maskedO):
#        if masked == 0:
#            pixel = green
#        else:
#            pixel = 22.1584 * (np.log(green)/np.log(blue)) - 22.94

saveImage(result, imgWidth, imgHeight)

