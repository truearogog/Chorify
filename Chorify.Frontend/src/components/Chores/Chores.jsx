import { useState, useEffect, useRef } from "react";
import axios from "axios";
import "./chores.css";
import "./choresForm.css";

const Chores = () => {
  const [items, setItems] = useState([]);
  const [expandedItems, setExpandedItems] = useState({});
  const [expandedItemId, setExpandedItemId] = useState("");
  const [showEditDeleteButtons, setShowEditDeleteButtons] = useState(false);
  const columnsRef = useRef([]);
  const [showModal, setShowModal] = useState(false);
  const [editShowModal, setEditShowModal] = useState(false);

  const [choreData, setChoreData] = useState({
    name: "",
    description: "",
    color: "",
  });

  const [editChoreData, setEditChoreData] = useState({
    id: "",
    name: "",
    description: "",
    color: "",
  });

  const handleChoreInput = (e) => {
    setChoreData((prev) => ({ ...prev, [e.target.name]: e.target.value }));
    console.log(choreData);
  };

  const handleEditChoreInput = (e) => {
    setEditChoreData((prev) => ({ ...prev, [e.target.name]: e.target.value }));
    console.log(editChoreData);
  };

  const handleChoreSubmit = async () => {
    try {
      await axios.post("http://localhost:5160/api/Chore/create", choreData, {
        withCredentials: true,
      });
    } catch (error) {
      console.log(error);
    }
  };

  const handleEditChoreSubmit = async () => {
    try {
      editChoreData.id = expandedItemId;
      await axios.post(
        "http://localhost:5160/api/Chore/update",
        editChoreData,
        {
          withCredentials: true,
        }
      );
    } catch (error) {
      console.log(error);
    }
  };

  const handleColorChange = (e) => {
    setChoreData((prev) => ({ ...prev, [e.target.name]: e.target.value }));
    console.log(choreData);
  };

  const handleEditColorChange = (e) => {
    setEditChoreData((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };

  const handleExpandClick = (itemId) => {
    setExpandedItems((prevExpandedItems) => ({
      ...prevExpandedItems,
      [itemId]: !prevExpandedItems[itemId],
    }));
    setExpandedItemId(itemId);
    setShowEditDeleteButtons(true);
  };

  const handleDeleteClick = async (itemId) => {
    try {
      const data = { id: itemId };
      await axios.post("http://localhost:5160/api/Chore/delete", data, {
        withCredentials: true,
      });
      setItems(items.filter((item) => item.id !== itemId));
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    const fetchItems = async () => {
      try {
        const { data } = await axios.get(
          "http://localhost:5160/api/Chore/all",
          { withCredentials: true }
        );
        setItems(data.data);
        console.log(data.data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchItems();
  }, []);

  useEffect(() => {
    const calculateColumnHeights = () => {
      const columnHeights = columnsRef.current.map(
        (column) => column.offsetHeight
      );
      const maxColumnHeight = Math.max(...columnHeights);
      columnsRef.current.forEach((column) => {
        column.style.height = `${maxColumnHeight}px`;
      });
    };
    calculateColumnHeights();
  }, [items]);

  const handleAddChoreClick = () => {
    setShowModal(true);
  };

  const handleCloseModalClick = () => {
    setShowModal(false);
  };

  const handleEditChoreClick = () => {
    setEditShowModal(true);
  };

  const handleCloseEditModalClick = () => {
    setEditShowModal(false);
  };

  return (
    <div className="mainContainer">
      <div className="buttonContainer">
        <button className="addChoreButton">Add chore</button>
      </div>
      <div className="buttonContainer">
        <button className="addChoreButton" onClick={handleAddChoreClick}>
          Add chore
        </button>
      </div>
      {showModal && (
        <div className="modalBackground">
          <div className="modalContainer">
            <div className="modalHeader">
              <h2>Add Chore</h2>
              <button
                className="closeModalButton"
                onClick={handleCloseModalClick}
              >
                X
              </button>
            </div>
            <form onSubmit={handleChoreSubmit} className="modalForm">
              <label htmlFor="choreName">Name</label>
              <input
                onChange={handleChoreInput}
                type="text"
                id="name"
                name="name"
              />
              <label htmlFor="choreDescription">Description</label>
              <textarea
                onChange={handleChoreInput}
                id="description"
                name="description"
              ></textarea>
              <label htmlFor="choreColor">Color</label>
              <input
                className="color-picker"
                type="color"
                id="color"
                name="color"
                onChange={handleColorChange}
              />
              <button className="submitChoreButton" type="submit">
                Add Chore
              </button>
            </form>
          </div>
        </div>
      )}
      <div className="choresContainer">
        {[0, 1, 2, 3].map((i) => (
          <div
            className="column"
            key={i}
            ref={(el) => (columnsRef.current[i] = el)}
          >
            {items.slice(i * 9, i * 9 + 9).map((item) => (
              <div
                className={`choreItem ${
                  expandedItems[item.id] ? "expanded" : ""
                }`}
                style={{ backgroundColor: item.color }}
                key={item.id}
              >
                <div className="choreItemHeader">
                  <div className="choreItemName">{item.name}</div>
                  <button
                    className="expandButton"
                    onClick={() => handleExpandClick(item.id)}
                  >
                    {expandedItems[item.id] ? "-" : "+"}
                  </button>
                </div>
                {expandedItems[item.id] && (
                  <div className="choreItemDetails">
                    <div className="choreItemDescription">
                      {item.description}
                    </div>
                    <div className="deleteEditButtons">
                      <button
                        className="deleteChoreButton"
                        onClick={() => handleDeleteClick(item.id)}
                      >
                        Delete
                      </button>
                      <button
                        className="editChoreButton"
                        onClick={() => handleEditChoreClick(item.id)}
                      >
                        Edit
                      </button>
                      {editShowModal && (
                        <div className="modalBackground">
                          <div className="modalContainer">
                            <div className="modalHeader">
                              <h2>Edit Chore</h2>
                              <button
                                className="closeModalButton"
                                onClick={handleCloseEditModalClick}
                              >
                                X
                              </button>
                            </div>
                            <form
                              onSubmit={handleEditChoreSubmit(item.id)}
                              className="modalForm"
                            >
                              <label htmlFor="choreName">Name</label>
                              <input
                                onChange={handleEditChoreInput}
                                type="text"
                                id="name"
                                name="name"
                              />
                              <label htmlFor="choreDescription">
                                Description
                              </label>
                              <textarea
                                onChange={handleEditChoreInput}
                                id="description"
                                name="description"
                              ></textarea>
                              <label htmlFor="choreColor">Color</label>
                              <input
                                className="color-picker"
                                type="color"
                                id="color"
                                name="color"
                                onChange={handleEditColorChange}
                              />
                              <button
                                className="submitChoreButton"
                                type="submit"
                              >
                                Edit Chore
                              </button>
                            </form>
                          </div>
                        </div>
                      )}
                    </div>
                  </div>
                )}
              </div>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
};

export default Chores;
