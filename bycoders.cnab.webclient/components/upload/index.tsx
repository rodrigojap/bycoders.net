export const UploadFile = ({ saveFile, handleUpload }) => {  
    return (
    <div>
      <input type="file" className="input-attach" onChange={saveFile}></input>
      <button                
        id="btn-submit"
        className="btn-submit-class"
        onClick={() => handleUpload()}
      >Enviar Arquivo</button>
    </div>
  );
};
