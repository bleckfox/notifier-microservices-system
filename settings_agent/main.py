import os
import json
from typing import Union
from fastapi import FastAPI, HTTPException, Depends

app = FastAPI()

def get_settings_directory():
    return '/app/setting_files'

# Function to read JSON content from a file
def read_json_file(file_path: str):
    try:
        with open(file_path, 'r') as file:
            content = file.read()
        return json.loads(content)
    except FileNotFoundError:
        raise HTTPException(status_code=404, detail='File not found...')
    except json.JSONDecodeError:
        raise HTTPException(status_code=500, detail='Error decoding JSON...')
    except Exception as e:
        raise HTTPException(status_code=500, detail=f'Internal error: {str(e)}')

# Dependency to get the "setting files" directory path
settings_directory = Depends(get_settings_directory)

@app.get("/get_settings/{settings}")
async def get_db_settings(settings: str, settings_directory: str = settings_directory):
    file_path = os.path.join(settings_directory, f'{settings}Settings.json')
    return read_json_file(file_path)
