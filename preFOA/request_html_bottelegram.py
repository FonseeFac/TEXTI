
from cgitb import text
import json 
import requests
import os

from pickle import GET
from re import search
from datetime import date


##TOKEN DE BOT
TOKEN = "5629629659:AAHTd6Uqpcboo2N-_YVMHzOGA3_U0LDP7QE"
FECHA_ACTUAL = date.today()
OFFSET = 0

##Funcion para obtener el PATH de las imagenes 
#
#
#
def obtener_filepath(FILE_ID):

    ##METODO GETFILE
    MODO = 'getFile'
    
    url = "https://api.telegram.org/bot{0}/{1}".format(TOKEN,MODO)
    myObj = {'file_id':FILE_ID}
    response = requests.post(url,myObj).json()

    respuesta = json.dumps(response)
    respuesta = json.loads(respuesta)

    ruta = respuesta["result"]
    ruta = ruta["file_path"]
    ##TRANSFORMAMOS LA RESPUESTA EN STRING
    return ruta
    

##FUNCION PARA OBTENER LOS MENSAJES DEL BOT
# 
# 
#     
def obtener_mensajes():
    #METODO de Telegram(getUpdates,MessageId,etc)
    
    MODO = "getUpdates"
    CANTIDAD_MENSAJES = 0

    ##myObj es el objeto que envio para la peticion HTTP
    myObj = {'offset':OFFSET}
    
    ##URL de la api de telegram, TOKEN = TOKEN BOT y MODO = tipo de metodo enviado
    url = "https://api.telegram.org/bot{0}/{1}".format(TOKEN,MODO)
    
    ##Realizo la Request, enviando la url y el objeto
    response = requests.post(url,myObj).json()

    ##Doy formato a response
    
    
    return response
    
##Funcion para formatear los datos del string
#
#
#
def formatear_datos(respuesta_txt):
    OFFSET = 0
    
    ##Reemplazamos los 'update_id' por un salto de linea
    stream_datos = json.dumps(respuesta_txt)
    stream_datos = json.loads(stream_datos)
    
    ##Guardo la respuesta en un archivo (ESCRITORIO/PruebPython.txt)
    stream_archivo = open("C:\\Users\\computos2\\Desktop\\FOA{0}.txt".format(FECHA_ACTUAL),"w")

    for i in stream_datos["result"]:
        stream_datos_procesados = ""
        texto = ""

        if "photo" in i["message"] :
            texto = eliminar_saltos_linea(str(i["message"]["caption"]))
            stream_datos_procesados = (i["message"]["from"]["first_name"]+"\n"+ str(i["update_id"])
                                      +"\n"+ texto +"\n\n")
            stream_archivo.write("{0}".format(stream_datos_procesados))
            
            path = obtener_filepath(i["message"]["photo"][3]["file_id"])
            
            obtener_foto(str(i["update_id"]),path)
       
        elif "text" in i["message"]:
            
            texto = eliminar_saltos_linea(str(i["message"]["text"]))
            stream_datos_procesados = (str(i["message"]["from"]["first_name"])+"\n"  
                                     + str(i["update_id"])+"\n"+ texto + "\n\n")
            
            stream_archivo.write("{0}".format(stream_datos_procesados))
        
        elif "document" in i["message"]:
            
            texto = str(i["message"]["caption"])
            stream_datos_procesados = (str(i["message"]["from"]["first_name"])+ "\n" +
             str(i["update_id"]) + "\n" + texto + "\n\n")
            
            stream_archivo.write("{0}".format(stream_datos_procesados))


    
    

    ##Si el stream_datos contiene al menos un update_id suma a OFFSET esa cantidad 
    CANTIDAD_MENSAJES = stream_datos_procesados.count("update_id")

    ##Sumo a OFFSET la cantidad de datos que lei, para que solo tome los updates nuevos
    ##OFFSET = OFFSET + CANTIDAD_MENSAJES

    stream_archivo.close()


##Funcion para descargar la foto adjunta al archivo
#
#
#
def obtener_foto(update_id,path):
    #METODO de Telegram(getUpdates,MessageId,etc)
    ##FILE_ID = 'AgACAgEAAxkBAAMhYzQ3UDavc78uW27mxmrPppVq-3kAAp2qMRttjKBFSsTwy3pdZv4BAAMCAANzAAMqBA'
    MODO = path

    url = "https://api.telegram.org/file/bot{0}/{1}".format(TOKEN,MODO)

    response = requests.get(url).content

    with open("C:\\Users\\computos2\\Desktop\\FOA{0}.jpg".format(update_id),"wb") as handler:
        handler.write(response)

##Eliminamos saltos de linea
#
#
#
def eliminar_saltos_linea(string):
    salida1 = ""
    salida1 = string.replace('\n'," ")
    salida = salida1.replace('/foa','')
    return salida


##Funcion MAIN para llamar los procesos
#
#
#
def main():
    
    respuesta_txt = obtener_mensajes()
    formatear_datos(respuesta_txt)
main()

