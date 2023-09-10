export const UploadFile = ({ saveFile, handleUpload }) => {  
    return (
    <div>
      <input type="file" onChange={saveFile}></input>
      <input
        type="button"
        value="upload"
        onClick={() => handleUpload()}
      ></input>
    </div>
  );
};
